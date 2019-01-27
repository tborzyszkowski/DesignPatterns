<?php

namespace App;

// testy
$client = new API();
$client->register();
$client->login();
$client->getProducts();
$client->getProduct(5);
$client->getProductsInCart();
