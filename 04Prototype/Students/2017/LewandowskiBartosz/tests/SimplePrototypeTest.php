<?php
namespace Blewandowski\Tests;

use PHPUnit\Framework\TestCase;
use Blewandowski\SimplePrototype\ProgrammingBook;

class SimplePrototypeTest extends TestCase
{
    public function test_is_ProgrammingBook_clonable()
    {
        $programmingBook = new ProgrammingBook();
        $programmingBook
            ->setId(1)
            ->setAuthor("Robert C. Martin")
            ->setTitle("Clean Code");
        
        $anotherOneBook = clone $programmingBook;
        $anotherOneBook->setTitle("Working effectively with legacy code");
        
        $this->assertNotEquals($programmingBook->getTitle(), $anotherOneBook->getTitle());
        $this->assertEquals($programmingBook->getAuthor(), $anotherOneBook->getAuthor());
    }
  
}

