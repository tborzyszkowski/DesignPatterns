<?php

interface Entity
{
    public function accept(Visitor $visitor): string;
}

class Shop implements Entity
{
    private $name;
    private $departments;

    public function __construct(string $name, array $departments)
    {
        $this->name = $name;
        $this->departments = $departments;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getDepartments(): array
    {
        return $this->departments;
    }

    public function accept(Visitor $visitor): string
    {
        return $visitor->visitCompany($this);
    }
}

//komponent okreslajacy konkretny sklep

class Megatron implements Entity
{
    private $name;

    private $user;

    public function __construct(string $name, string $user)
    {
        $this->name = $name;
        $this->user = $user;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getUser(): string
    {
        return $this->user;
    }

    public function getCost(): int
    {
        $cost = 0;
        foreach ($this->user as $user) {
            $cost += $user->getBalance();
        }

        return $cost;
    }


    public function accept(Visitor $visitor): string
    {
        return $visitor->visitDepartment($this);
    }
}

//komponent identyfikujacy urzytkowników
class User implements Entity
{
    private $name;

    private $id;

    private $balance;

    public function __construct(string $name, int $balance, int $id)
    {
        $this->name = $name;
        $this->balance = $balance;
        $this->id = $id;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getBalance(): int
    {
        return $this->balance;
    }

    public function getId(): int
    {
        return $this->id;
    }

    public function accept(Visitor $visitor): string
    {
        return $visitor->visitUser($this);
    }
}

//wizitator implementacje wszytkich odwiedzanych komponentów
interface Visitor
{
    public function visitCompany(Shop $company): string;

    public function visitDepartment(Megatron $department): string;

    public function visitUser(User $user): string;
}

class DebtRaport implements Visitor
{
    public function visitCompany(Shop $company): string
    {
        $output = "";
        $total = 0;

        foreach ($company->getDepartments() as $department) {
            $total += $department->getCost();
            $output .= "\n--" . $this->visitDepartment($department);
        }

        $output .= $company->getName();


        return $output;
    }

    public function visitDepartment(Megatron $department): string
    {
        $output = "";


        $output .= $department->getUser() . "   ";


        $output .= $department->getName();

        return $output;
    }

    public function visitUser(User $user): string
    {
        return money_format("%#6n", $user->getSalary()) .
            " " . $user->getName() .
            " (" . $user->getBalance() . ")\n";
    }
}

$adam = serialize(new User("Adam", 20, 34455));
$ewa = serialize(new User("Ewa", 12, 234));
$usersDebt = new Megatron("Computer Shop",$adam, $ewa);

$company = new Shop("Megatron", [$usersDebt]);

$report = new DebtRaport();
//echo var_dump($report);

echo "\nClient: Megatron users in debt:\n\n";
$usersDebt->accept($report);


echo '<pre>' . print_r($usersDebt, 1) . '</pre>';
