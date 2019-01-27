<?php

abstract class Burger
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
}

class SurfBurger extends Burger
{
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

class PasiBus extends Burger
{
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

class BobbyBurger extends Burger
{
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

class SimpleBurgerFactory
{
    private static $instance;

    private function __construct()
    {
    }

    public static function getInstance()
    {
        if(self::$instance === null)
            self::$instance = new SimpleBurgerFactory();
        return self::$instance;
    }

    public function getBurgerPlace($place, $type)
    {
        if ($place == "SurfBurger") {
            return (new SurfBurger($type))->getBurger();
        } elseif ($place == "PasiBus") {
            return (new PasiBus($type))->getBurger();
        } elseif ($place == "BobbyBurger") {
            return (new BobbyBurger($type))->getBurger();
        }
    }
}

$burger = SimpleBurgerFactory::getInstance();

echo $burger->getBurgerPlace("BobbyBurger", "alibaba")."\n";
echo $burger->getBurgerPlace("SurfBurger", "gangsta")."\n";
echo $burger->getBurgerPlace("PasiBus", "bebek")."\n";