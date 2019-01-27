<?php

namespace App;


$image = new ProxyImage(['width' => 3800, 'height' => 2000], 'tajne');
$image2 = new ProxyImage(['width' => 3800, 'height' => 2000], 'tajne2');
$image->display(); // wyswietli "display image"
$image2->display(); // wyswietli "Access denied"