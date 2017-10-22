<?php

namespace Blewandowski\Tests;

use Blewandowski\Serialization\Singleton;
use PHPUnit\Framework\TestCase;

class SerializeTest extends TestCase
{
    /**
     * @expectedException \BadMethodCallException
     */
    public function test_if_serialization_is_not_changing_state()
    {
        $singleton = Singleton::getInstance();

        $serializedSingleton = serialize($singleton);
        $unserializedSingleton = unserialize($serializedSingleton);
    }
    
    /**
     * @expectedException \BadMethodCallException
     */
    public function test_if_serialization_does_not_create_new_instance()
    {
        $singleton = Singleton::getInstance();
        
        $clonedSingleton = clone $singleton;
    }
}