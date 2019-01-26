<?php

interface BurgerFactory
{
    public function getBurger();
}

class SurfBurgerFactory implements BurgerFactory
{
    protected $type;
    private static $instance;

    private function __construct($type)
    {
        $this->type = $type;
    }

    public static function getInstance($type)
    {
        if(self::$instance === null)
            self::$instance = new SurfBurgerFactory($type);
        return self::$instance;
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

class PasiBusFactory implements BurgerFactory
{
    protected $type;
    private static $instance;

    private function __construct($type)
    {
        $this->type = $type;
    }

    public static function getInstance($type)
    {
        if(self::$instance === null)
            self::$instance = new PasiBusFactory($type);
        return self::$instance;
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

class BobbyBurgerFactory implements BurgerFactory
{
    protected $type;
    private static $instance;

    private function __construct($type)
    {
        $this->type = $type;
    }

    public static function getInstance($type)
    {
        if(self::$instance === null)
            self::$instance = new BobbyBurgerFactory($type);
        return self::$instance;
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
        return "Zamówiłeś burgera Grazyna z BobbyBurger";
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

echo $burger = BobbyBurgerFactory::getInstance("grazyna")->getBurger()."\n";
echo $burger = SurfBurgerFactory::getInstance("specjal")->getBurger()."\n";
echo $burger = PasiBusFactory::getInstance("klasyk")->getBurger()."\n";
