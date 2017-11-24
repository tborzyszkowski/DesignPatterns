<?php

namespace Blewandowski\SimpleFactory;

use Blewandowski\SimpleFactory\Entity\TrialUser;
use Blewandowski\SimpleFactory\ValueObject\Email;
use Blewandowski\SimpleFactory\Entity\StandardUser;
use Blewandowski\SimpleFactory\Entity\PremiumUser;

class UserSimpleFactory
{
    private function __construct()
    {
        //prevent to call instance statically
    }
    
    public static function create($name, $email, $type)
    {
        switch($type) {
            case 'trial':
                $user = new TrialUser($name, new Email($email));
                break;
            case 'standard':
                $user = new StandardUser($name, new Email($email));
                break;
            case 'premium':
                $user = new PremiumUser($name, new Email($email));
                break;
            default:
                throw new \BadMethodCallException("There is no type: " . $type);
                break;
        }

        return $user;
    }
}