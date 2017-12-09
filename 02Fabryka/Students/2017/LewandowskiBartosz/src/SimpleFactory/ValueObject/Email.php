<?php

namespace Blewandowski\SimpleFactory\ValueObject;

class Email 
{
    private $email;

    public function __construct(string $email)
    {
        if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
            throw new \Exception('Incorrect email addres');
        }

        $splitEmail = explode('@', $email);

        if(!checkdnsrr($splitEmail[1], 'MX')) {
            throw new \Exception('There is no domain like '.$splitEmail[1]);
        }

        $this->email = $email;
    }

    public function __toString()
    {
        return $this->email;
    }
}