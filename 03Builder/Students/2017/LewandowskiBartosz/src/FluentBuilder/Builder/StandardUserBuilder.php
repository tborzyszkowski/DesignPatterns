<?php
namespace Blewandowski\FluentBuilder\Builder;

use Blewandowski\FluentBuilder\BuilderInterface;
use Blewandowski\FluentBuilder\Entity\User;

class StandardUserBuilder implements BuilderInterface
{
    public function __construct()
    {
        $this->user = new User();
    }
    
    public function name($name)
    {
        $this->user->setName($name);
        
        return $this;
    }
    
    public function email($email)
    {
        $this->user->setEmail($email);
        
        return $this;
    }
    
    public function privileges()
    {
        $this->user->addPrivileges('Pisanie komentarzy pod wpisami na tablicy');
        
        return $this;
    }

    public function status()
    {
        $this->user->setActive(true);
        
        return $this;
    }

    public function group()
    {
        $this->user->addGroup('standard');
        
        return $this;
    }
    
    public function build()
    {
        return $this->user;
    }
}