<?php

namespace App;


class SingletonSer
{
    public static $instance;

    public $hello = 'Hello';
    public $world = 'World';

    public static function getInstance()
    {
        if (self::$instance === null) {
            self::$instance = new SingletonSer();
        }

        return self::$instance;
    }

}


$firstInstance = SingletonSer::getInstance();

$file = fopen('file.txt','r');

$read = fread($file,filesize('file.txt'));

$secondInstance = unserialize($read);

if ($firstInstance === $secondInstance::$instance) {
    echo "Istnieje tylko jedna instancja klasy SingletonSer";
} else {
    echo "Instancje klasy SingletonSer są różne";
}

echo "<br>";
echo "<br>";

echo spl_object_hash ($firstInstance)."<br>";
echo spl_object_hash ($secondInstance::$instance)."<br>";

echo "<br>";

var_dump($firstInstance);
var_dump($secondInstance::$instance);







