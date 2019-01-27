<?php


namespace App;


class User
{
    protected $session;

    public function __construct(Session $session)
    {
        $this->session = $session;
    }

    public function setName($name)
    {
        $this->session->set('name', $name);
    }

    public function getName()
    {
        return $this->session->get('name');
    }

    public function login()
    {
        echo "Logowanie do systemu\n";
    }

    public function register()
    {
        echo "Rejestracja\n";
    }
}