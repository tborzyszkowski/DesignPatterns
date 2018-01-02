<?php
namespace Blewandowski\Tests;

use Blewandowski\SimpleBuilder\Entity\User;
use Blewandowski\SimpleBuilder\UserSimpleBuilder;
use PHPUnit\Framework\TestCase;

class SimpleBuilderTest extends TestCase
{
    public function test_is_builder_working_correctly()
    {
        $builder = new UserSimpleBuilder();
        $builder->name("Bartosz Lewandowski");
        $builder->email("mail@domain.example");
        $builder->contactData("address here", "+48 123 456 789");
        $actual = $builder->build();
        
        $expected = new User();
        $expected->setName("Bartosz Lewandowski");
        $expected->setEmail("mail@domain.example");
        $expected->setAddress("address here");
        $expected->setPhone("+48 123 456 789");
     
        $this->assertEquals($expected, $actual);
    }
}