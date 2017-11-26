<?php
namespace Blewandowski\FluentBuilder\Builder;

use Blewandowski\FluentBuilder\BuilderInterface;
use Blewandowski\FluentBuilder\Entity\User;

class ModeratorUserBuilder implements BuilderInterface
{
    private $user;
    
    public function __construct()
    {
        $this->user = new User();
    }
    
    public function name($name)
    {
        $this->user->setName("Mod " . $name);
        
        return $this;
    }

    public function email($email)
    {
        $this->user->setEmail($email);
        
        return $this;
    }
    
    public function group()
    {
        $this->user->addGroup('standard'); 
        $this->user->addGroup('moderator');
        
        return $this;
    }
    
    public function privileges()
    {
        $this->user->addPrivileges('Przypinanie wpisów na początek tablicy');
        $this->user->addPrivileges('Pisanie komentarzy pod wpisami na tablicy');
        $this->user->addPrivileges('Możliwość edycji komentarzy, nadawanie ostrzeżeń i kar użytkownikom');
        $this->user->addPrivileges('Tymczasowa banicja użytkownika');
        
        return $this;
    }
    
    public function status()
    {
        $this->user->setActive(true);
        
        return $this;
    }
    
    public function build()
    {
        return $this->user;
    }

}

