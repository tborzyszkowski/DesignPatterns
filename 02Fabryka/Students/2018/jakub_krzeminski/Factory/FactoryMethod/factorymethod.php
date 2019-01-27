<?php

interface Burger
{
    public function getBurger();
}

class SurfBurger implements Burger
{
    protected $type;

    public function __construct($type)
    {
        $this->type = $type;

        return $this;
    }

    public function getBurger()
    {
        $type = $this->type;

        return $this->$type();
    }

    public function dzik()
    {
        return "Zamówiłeś burgera Dzik z SurfBurger";
    }

    public function doubleTrouble()
    {
        return "Zamówiłeś burgera Double Trouble z SurfBurger";
    }

    public function gangsta()
    {
        return "Zamówiłeś burgera Gangsta z SurfBurger";
    }

    public function specjal()
    {
        return "Zamówiłeś burgera Specjal z SurfBurger";
    }
}

class PasiBus implements Burger
{
    protected $type;

    public function __construct($type)
    {
        $this->type = $type;

        return $this;
    }

    public function getBurger()
    {
        $type = $this->type;

        return $this->$type();
    }

    public function klasyk()
    {
        return "Zamówiłeś burgera Klasyk z PasiBus";
    }

    public function standard()
    {
        return "Zamówiłeś burgera Standard Trouble z PasiBus";
    }

    public function wiesio()
    {
        return "Zamówiłeś burgera Wiesio z PasiBus";
    }

    public function bebek()
    {
        return "Zamówiłeś burgera Bebek z PasiBus";
    }
}

class BobbyBurger implements Burger
{
    protected $type;

    public function __construct($type)
    {
        $this->type = $type;

        return $this;
    }

    public function getBurger()
    {
        $type = $this->type;

        return $this->$type();
    }

    public function brajan()
    {
        return "Zamówiłeś burgera Brajan z BobbyBurger";
    }

    public function grazyna()
    {
        return "Zamówiłeś burgera Grazyna Trouble z BobbyBurger";
    }

    public function janush()
    {
        return "Zamówiłeś burgera Janush z BobbyBurger";
    }

    public function alibaba()
    {
        return "Zamówiłeś burgera Alibaba z BobbyBurger";
    }
}

abstract class FactoryMethod
{

    abstract protected function createBurger($place, $type);

    public function create($place, $type)
    {
        $obj = $this->createBurger($place, $type);
        return $obj;
    }
}

class FactoryBurgerMethod extends FactoryMethod
{
    private static $instance;

    private function __construct()
    {
    }

    public static function getInstance()
    {
        if(self::$instance === null)
            self::$instance = new FactoryBurgerMethod();
        return self::$instance;
    }

    public function createBurger($place, $type)
    {
        switch ($place) {
            case 'SurfBurger':
                return (new SurfBurger($type))->getBurger();
                break;
            case 'PasiBus':
                return (new PasiBus($type))->getBurger();
                break;
            case 'BobbyBurger':
                return (new BobbyBurger($type))->getBurger();
                break;
            default:
                throw new InvalidArgumentException();
        }
    }
}

$burger = FactoryBurgerMethod::getInstance();

echo $burger->create("BobbyBurger", "janush")."\n";
echo $burger->create("SurfBurger", "dzik")."\n";
echo $burger->create("PasiBus", "wiesio")."\n";
