<?php

namespace Blewandowski\Serialization;


class Singleton implements \Serializable
{
    private static $instance;

    public static function getInstance()
    {
        if(!self::$instance) {
            self::$instance = new self();
        }
        return self::$instance;
    }

    public function serialize()
    {
        throw new \BadMethodCallException(
            'This class is a singleton, you can not serialize it'
        );
    }

    public function unserialize($data)
    {
        throw new \BadMethodCallException('This class is a singleton, you can not unserialize it');
    }

    public function __clone() 
    {
        throw new \BadMethodCallException('This class is a singleton, you can not clone it');
    }
}