<?php

namespace Blewandowski\Tests\Inheritance;

use Blewandowski\Inheritance\ExtendedLogger;
use PHPUnit\Framework\TestCase;

class ExtendedLoggerTest extends TestCase
{
    public function test_if_instance_of_extended_logger_is_correct()
    {
        $this->assertInstanceOf(ExtendedLogger::class, ExtendedLogger::getInstance());
    }

    public function test_if_instance_of_extended_logger_required_methods()
    {
        $expectedMethods = ['writeToRedis', 'writeToElasticSearch', 'writeToSyslog', 'getInstance'];
        $this->assertEquals($expectedMethods, get_class_methods(ExtendedLogger::getInstance()));
    }

    public function test_methods()
    {
        $this->assertEquals("Redis: TestString", ExtendedLogger::getInstance()->writeToRedis("TestString"));
        $this->assertEquals("ElasticSearch: TestString", ExtendedLogger::getInstance()->writeToElasticSearch("TestString"));
        $this->assertEquals("Syslog: TestString", ExtendedLogger::getInstance()->writeToSyslog("TestString"));
    }
}
