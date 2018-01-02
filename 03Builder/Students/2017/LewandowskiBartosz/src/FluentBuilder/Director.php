<?php
namespace Blewandowski\FluentBuilder;

class Director
{
    private $builder;
    
    public function __construct(BuilderInterface $builder)
    {
        $this->builder = $builder;
    }
    
    public function makeUser($name, $email)
    {
        $this->builder
            ->name($name)
            ->email($email)
            ->status()
            ->privileges()
            ->group();
    }
    
    public function getUser()
    {
        return $this->builder->build();
    }
}