<?php

namespace App;


$session = new Session("MY SESSION");
$user = new User($session);
$user->setName("login");
echo $user->getName();