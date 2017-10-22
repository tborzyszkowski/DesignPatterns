<?php

namespace Blewandowski\Tests\Inheritance;

use Blewandowski\Inheritance\Logger;
use PHPUnit\Framework\TestCase;

class LoggerTest extends TestCase
{
    public function test_if_instance_of_logger_is_correct()
    {
        $this->assertInstanceOf(Logger::class, Logger::getInstance());
    }

    public function test_if_instance_of_logger_required_methods()
    {
        $expectedMethods = ['writeToSyslog', 'getInstance'];
        $this->assertEquals($expectedMethods, get_class_methods(Logger::getInstance()));
    }

    public function test_methods()
    {
        $this->assertEquals("Syslog: TestString", Logger::getInstance()->writeToSyslog("TestString"));
    }
}
