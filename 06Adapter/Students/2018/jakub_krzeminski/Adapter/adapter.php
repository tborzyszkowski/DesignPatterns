<?php

class Burger
{
    private $brand;
    private $type;


    public function setBrand($brand)
    {
        $this->brand = $brand;
    }


    public function setType($type)
    {
        $this->type = $type;
    }


    public function getBrand()
    {
        return $this->brand;
    }


    public function getType()
    {
        return $this->type;
    }
}

class Brand
{
    public static function getBurger($type)
    {
        $burger = new Burger();
        $burger->setBrand("SurfBurger");
        $burger->setType($type);
        return $burger;
    }
}

class Delivery
{
    public static function getFormDelivery($delivery)
    {
        switch ($delivery) {
            case 1:
                return "Delivery to home";
                break;
            case 2:
                return "Delivery to office";
                break;
            default:
                return "Personal receive";
                break;
        }
    }
}

class Adapter extends Delivery
{
    private $request;

    public function __construct($obj)
    {
        switch (get_class($obj))
        {
            case 'Brand':
                $this->request = 'Brand::getBurger';
                break;
            case 'Delivery':
                $this->request = 'Adapter::getBurger';
                break;
        }
    }

    public function Request()
    {
        return $this->request;
    }

    public static function getBurger($type)
    {
        $burger = new Burger();
        $burger->setType($type);
        $formDelivery = Delivery::getFormDelivery(true);
        $burger->setBrand($formDelivery.' by SurfBurger');
        return $burger;
    }

    public function changeRequest($function)
    {
        $this->request = $function;
    }

}

//test klasy Burger z Adapterem

$adapter = new Adapter(new Brand());
$burger = $adapter->Request()('Dzik');

print_r($burger);

//test klasy Delivery z Adapterem

$adapter = new Adapter(new Delivery());
$burger2 = $adapter->Request()("Gangsta");

print_r($burger2);

//test ze zmiana request Adapter

$adapter = new Adapter(new Delivery());
$adapter->changeRequest('Brand::getBurger');
$burger3 = $adapter->Request()('Double Trouble');

print_r($burger3);