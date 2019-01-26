<?php

namespace App;

// testy
$product = new Product("produkt 1", 100, "PriceForNewClient");
echo "Nazwa produktu: ".$product->getName().", cena produktu: ".$product->getPrice()."\n";
$product->setStrategy("PriceForRegularClient");
echo "Nazwa produktu: ".$product->getName().", cena produktu: ".$product->getPrice()."\n";
$product->setStrategy("PriceForWholesaler");
echo "Nazwa produktu: ".$product->getName().", cena produktu: ".$product->getPrice();