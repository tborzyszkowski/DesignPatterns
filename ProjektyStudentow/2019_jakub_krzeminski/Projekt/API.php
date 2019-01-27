<?php
/**
 * Created by PhpStorm.
 * User: krzemson
 * Date: 25.01.2019
 * Time: 02:18
 */

namespace App;


class API
{
    private $user;
    private $cart;
    private $product;

    public function __construct()
    {
        $this->user = new User(new Session());
        $this->cart = new Cart();
        $this->product = new Product();
    }

    public function login()
    {
        $this->user->login();
    }

    public function register()
    {
        $this->user->register();
    }

    public function getProductsInCart()
    {
        $this->cart->getItems();
    }

    public function getProducts()
    {
        $this->product->getAll();
    }

    public function getProduct($id)
    {
        $this->product->get($id);
    }
}