<?php
namespace Blewandowski\Tests;

use PHPUnit\Framework\TestCase;
use Blewandowski\FluentBuilder\Director;
use Blewandowski\FluentBuilder\Builder\StandardUserBuilder;
use Blewandowski\FluentBuilder\Entity\User;
use Blewandowski\FluentBuilder\Builder\ModeratorUserBuilder;

class FluentBuilderTest extends TestCase
{
    public function test_is_StandardUserBuilder_working_correctly()
    {
        $director = new Director(new StandardUserBuilder());
        $director->makeUser('Bartosz Lewandowski', 'mail@domain.example');
        $actual = $director->getUser();
        
        $expected = new User();
        $expected->setName('Bartosz Lewandowski');
        $expected->setEmail('mail@domain.example');
        $expected->setActive(true);
        $expected->addGroup('standard');
        $expected->addPrivileges('Pisanie komentarzy pod wpisami na tablicy');
        
        $this->assertEquals($expected, $actual);
    }
    
    public function test_is_ModeratorUserBuilder_working_correctly()
    {
        $director = new Director(new ModeratorUserBuilder());
        $director->makeUser('Bartosz Lewandowski', 'mail@domain.example');
        $actual = $director->getUser();
        
        $expected = new User();
        $expected->setName('Mod Bartosz Lewandowski');
        $expected->setEmail('mail@domain.example');
        $expected->setActive(true);
        $expected->addGroup('standard');
        $expected->addGroup('moderator');
        $expected->addPrivileges('Przypinanie wpisów na początek tablicy');
        $expected->addPrivileges('Pisanie komentarzy pod wpisami na tablicy');
        $expected->addPrivileges('Możliwość edycji komentarzy, nadawanie ostrzeżeń i kar użytkownikom');
        $expected->addPrivileges('Tymczasowa banicja użytkownika');
        
        
        $this->assertEquals($expected, $actual);
    }
}