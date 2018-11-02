<?php

namespace App;


class Singleton
{
    protected static $instance;

    public static function getInstance()
    {
        if (self::$instance === null) {
            self::$instance = new Singleton();
        }

        return self::$instance;
    }
}

class SubSingleton extends Singleton
{
    protected static $instance;

    public static function getInstance()
    {
        if (self::$instance === null) {
            self::$instance = new SubSingleton();
        }

        return self::$instance;
    }
}

$singleton = Singleton::getInstance();
$singleton2 = SubSingleton::getInstance();

print_r($singleton);
print_r($singleton2);