<?php
namespace Blewandowski\FluentBuilder;

interface BuilderInterface
{
    public function name($name);
   
    public function email($email);
   
    public function privileges();
    
    public function status();
    
    public function group();
    
    public function build();
}

