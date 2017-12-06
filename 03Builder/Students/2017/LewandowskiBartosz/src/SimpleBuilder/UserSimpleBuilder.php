<?php
namespace Blewandowski\SimpleBuilder;

use Blewandowski\SimpleBuilder\Entity\User;

class UserSimpleBuilder
{
    private $user; 
    
    public function __construct()
    {
        $this->user = new User();
    }
    
    public function name($name)
    {
        $this->user->setName($name);
    }
    
    public function email($email)
    {
        $this->user->setEmail($email);
    }
    
    public function contactData($address, $phone) 
    {
        $this->user->setAddress($address);
        $this->user->setPhone($phone);
    }
    
    public function build()
    {
        return $this->user;
    }
}