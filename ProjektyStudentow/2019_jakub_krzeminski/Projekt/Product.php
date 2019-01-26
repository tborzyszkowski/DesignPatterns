<?php
/**
 * Created by PhpStorm.
 * User: krzemson
 * Date: 25.01.2019
 * Time: 02:20
 */

namespace App;


class Product
{
    private $name;
    private $basicPrice;
    private $strategyPrice;

    public function __construct($name = "", $basicPrice = null, Price $strategy = null) {
        $this->name=$name;
        $this->basicPrice=$basicPrice;
        $this->strategyPrice = new $strategy();
    }
    public function getPrice()
    {
        return $this->strategyPrice->count($this->basicPrice);
    }
    public function getName()
    {
        return $this->name;
    }
    public function setStrategy($strategy)
    {
        $this->strategyPrice = new $strategy();
    }

    public function getAll()
    {
        echo "Lista produktów\n";
    }

    public function get($id)
    {
        echo "Produkt o ID ".$id."\n";
    }
}