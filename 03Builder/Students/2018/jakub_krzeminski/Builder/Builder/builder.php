<?php

interface iBurgerBuilder
{
    public function addBread($bread);
    public function addSauce($sauce);
    public function addVegetable($vegetable);
    public function addMeat($meat);
}

abstract class Burger
{
    private $bread;
    private $sauce;
    private $vegetable = [];
    private $meat;

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
}

class SurfBurger extends Burger
{
    
}

class SurfBurgerBuilder implements iBurgerBuilder
{
    private $burger;

    public function __construct()
    {
        $this->burger = new SurfBurger();
    }

    public function addBread($bread)
    {
        $this->burger->setBread($bread);
        return $this;
    }

    public function addSauce($sauce)
    {
        $this->burger->setSauce($sauce);
        return $this;
    }

    public function addVegetable($vegetable)
    {
        $this->burger->setVegetable($vegetable);
        return $this;
    }

    public function addMeat($meat)
    {
        $this->burger->setMeat($meat);
        return $this;
    }

    public function build()
    {
        return $this->burger;
    }
}

class Pasibus extends Burger
{

}

class PasibusBuilder implements iBurgerBuilder
{
    private $burger;

    public function __construct()
    {
        $this->burger = new Pasibus();
    }

    public function addBread($bread)
    {
        $this->burger->setBread($bread);
        return $this;
    }

    public function addSauce($sauce)
    {
        $this->burger->setSauce($sauce);
        return $this;
    }

    public function addVegetable($vegetable)
    {
        $this->burger->setVegetable($vegetable);
        return $this;
    }

    public function addMeat($meat)
    {
        $this->burger->setMeat($meat);
        return $this;
    }

    public function build()
    {
        return $this->burger;
    }
}

class BobbyBurger extends Burger
{

}

class BobbyBurgerBuilder implements iBurgerBuilder
{
    private $burger;

    public function __construct()
    {
        $this->burger = new BobbyBurger();
    }

    public function addBread($bread)
    {
        $this->burger->setBread($bread);
        return $this;
    }

    public function addSauce($sauce)
    {
        $this->burger->setSauce($sauce);
        return $this;
    }

    public function addVegetable($vegetable)
    {
        $this->burger->setVegetable($vegetable);
        return $this;
    }

    public function addMeat($meat)
    {
        $this->burger->setMeat($meat);
        return $this;
    }

    public function build()
    {
        return $this->burger;
    }
}

$surfburger = (new SurfBurgerBuilder())
    ->addBread("white")
    ->addSauce("BBQ")
    ->addMeat("beef")
    ->addVegetable("tomato")
    ->addVegetable("letuce")
    ->addVegetable("cucumber")
    ->build();

$pasibus = (new PasibusBuilder())
    ->addBread("dark")
    ->addSauce("garlic")
    ->addMeat("pork")
    ->addVegetable("pepper")
    ->addVegetable("letuce")
    ->addVegetable("onion")
    ->build();

$bobbyburger = (new BobbyBurgerBuilder())
    ->addBread("dark")
    ->addSauce("ketchup")
    ->addMeat("fish")
    ->addVegetable("red onion")
    ->addVegetable("letuce")
    ->addVegetable("mushrooms")
    ->build();

print_r($bobbyburger);