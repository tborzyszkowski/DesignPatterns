<?php

namespace Blewandowski\Inheritance;


abstract class Singleton
{
    static private $instances = [];

    private function __construct()
    {
    }

    final public static function getInstance()
    {
        $calledClass = get_called_class();

        if (!isset(self::$instances[$calledClass])) {
            self::$instances[$calledClass] = new $calledClass();
        }

        return self::$instances[$calledClass];
    }

}