<?php
namespace Blewandowski\FluentBuilder\Entity;

class User
{
    private $name;
    
    private $email;
    
    private $group = [];
    
    private $active;
    
    private $privileges = [];
    
    public function getName()
    {
        return $this->name;
    }

    public function setName($name)
    {
        $this->name = $name;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function setEmail($email)
    {
        $this->email = $email;
    }

    public function getGroup()
    {
        return $this->group;
    }

    public function addGroup($group)
    {
        $this->group[] = $group;
    }

    public function getActive()
    {
        return $this->active;
    }

    public function setActive($active)
    {
        $this->active = $active;
    }

    public function getPrivileges()
    {
        return $this->privileges;
    }

    public function addPrivileges($privileges)
    {
        $this->privileges[] = $privileges;
    }
}