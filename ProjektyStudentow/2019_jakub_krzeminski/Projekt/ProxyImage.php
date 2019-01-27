<?php


namespace App;


class ProxyImage implements HighResolutionImage
{
    private $options;
    private $passwrd;
    private $image = null;
    public function __construct($options, $password)
    {
        $this->options=$options;
        $this->passwrd=$password;
    }
    public function display()
    {
        if ($this->passwrd=='tajne') {
            if ($this->image==null) {
                $this->image=new Image($this->options);
            }
            $this->image->display();
        } else {
            echo 'Access denied';
        }
    }
}