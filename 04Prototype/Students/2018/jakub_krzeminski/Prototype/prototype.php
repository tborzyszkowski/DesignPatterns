<?php

interface IBurgerPrototype
{
    public function normalCopy();
    public function deepCopy();
}

class Burger implements IBurgerPrototype
{
    private $brand;

    public function setBrand(Brand $brand):void
    {
        $this->brand = $brand;
    }

    public function getBrand():Brand
    {
        return $this->brand;
    }

    public function normalCopy():Burger
    {
        $copy = new Burger();
        $values = get_object_vars($this);
        foreach ($values as $key => $val)
        {
            if(is_object($val))
                $copy->$key = $val;
        }
        return $copy;
    }

    function deepCopy():Burger
    {
        $copy = new Burger();
        $values = get_object_vars($this);
        foreach ($values as $key => $val)
        {
            if(!is_object($val))
                $copy->$key = $val;
            else
                $copy->$key = $this->deepCopySubClass($val);
        }
        return $copy;
    }

    private function deepCopySubClass($object)
    {
        $class = get_class($object);
        $copy = new $class();
        $set = 'set';
        $values = $object->getObjectVars();
        foreach ($values as $key => $val)
        {
            $method = $set.$key;
            if(!is_object($val))
                $copy->$method($val);
            else
                $copy->$method($this->deepCopySubClass($val));
            $set = 'set';
        }
        return $copy;
    }
}

class Brand
{
    private $brand;
    private $type;

    public function setBrand(String $brand):void
    {
        $this->brand = $brand;
    }

    public function setType(Type $type):void
    {
        $this->type = $type;
    }

    public function getType():Type
    {
        return $this->type;
    }

    public function getObjectVars()
    {
        return get_object_vars($this);
    }
}

class Type
{
    private $name;
    private $size;

    public function setName(String $name):void
    {
        $this->name = $name;
    }

    public function setSize(String $size):void
    {
        $this->size = $size;
    }

    public function getObjectVars()
    {
        return get_object_vars($this);
    }
}

$type = new Type();
$type->setName('Dzik');
$type->setSize('XXL');
$brand = new Brand();
$brand->setBrand('SurfBurger');
$brand->setType($type);

$burger = new Burger();
$burger->setBrand($brand);

$burgerClone = $burger->normalCopy();

print_r($burger);
print_r($burgerClone);

$type2 = new Type();
$type2->setName('Dzik');
$type2->setSize('XXL');
$brand2 = new Brand();
$brand2->setBrand('SurfBurger');
$brand2->setType($type2);

$burger2 = new Burger();
$burger2->setBrand($brand2);
$brandOrigin = $burger2->getBrand();
$typeOrigin = $burger2->getBrand()->getType();

$burgerClone = $burger2->deepCopy();
$brandClone = $burgerClone->getBrand();
$typeClone = $burgerClone->getBrand()->getType();

print_r($burgerClone);
print_r($brandClone);
print_r($typeClone);
