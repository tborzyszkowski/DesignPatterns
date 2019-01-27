<?php


namespace App;


class Session
{
    public function __construct($name = 'NEW SESSION')
    {
        session_name($name);
        session_start();
    }

    public function set($key, $value)
    {
        $_SESSION[$key] = $value;
    }

    public function get($key)
    {
        return $_SESSION[$key];
    }
}