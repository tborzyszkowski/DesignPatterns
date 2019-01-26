<?php

abstract class Burger
{
    private $bread;
    private $sauce;
    private $vegetable = [];
    private $meat;
    private $cheese;

    public function setBread($bread)
    {
        $this->bread = $bread;
    }

    public function setSauce($sauce)
    {
        $this->sauce = $sauce;
    }

    public function setVegetable($vegetable)
    {
        $this->vegetable[] = $vegetable;
    }

    public function setMeat($meat)
    {
        $this->meat = $meat;
    }

    public function setCheese()
    {
        $this->cheese = true;
    }
}

class SurfBurger extends Burger
{

}

interface iBurgerFactory
{
    public function vegetableBurger();
    public function fishBurger();
    public function meatBurger();
    public function cheeseBurger();
}

class SurfBurgerFactory implements IBurgerFactory
{
    public function __construct()
    {
    }
    public function vegetableBurger()
    {
        $burger = new SurfBurger();
        $burger->setVegetable(['Cucumber', 'Tomato', 'Onion', 'Potato']);
        $burger->setSauce('Garlic');
        $burger->setBread('white');
        return $burger;
    }

    public function fishBurger()
    {
        $burger = new SurfBurger();
        $burger->setBread('white');
        $burger->setVegetable(['Cucumber', 'Tomato']);
        $burger->setMeat('Cod');
        $burger->setSauce('BBQ');
        return $burger;
    }

    public function meatBurger()
    {
        $burger = new SurfBurger();
        $burger->setBread('white');
        $burger->setVegetable(['Letuce', 'Tomato']);
        $burger->setMeat('Beef');
        $burger->setSauce('BBQ');
        return $burger;
    }

    public function cheeseBurger()
    {
        $burger = new SurfBurger();
        $burger->setBread('dark');
        $burger->setVegetable(['Onion', 'Tomato']);
        $burger->setMeat('Pork');
        $burger->setSauce('BBQ');
        $burger->setCheese();
        return $burger;
    }
}

$stoper_start = microtime(true);  // start pomiaru

for ($i = 0; $i <10000; $i++) {
    $surfburger = new SurfBurgerFactory();
    $vegetableBurger = $surfburger->vegetableBurger();
    $cheeseBurger = $surfburger->cheeseBurger();
    $meatBurger = $surfburger->meatBurger();
    $fishBurger = $surfburger->fishBurger();
}


$stoper_stop = microtime(true); //koniec pomiaru

echo bcsub($stoper_stop, $stoper_start, 4);
