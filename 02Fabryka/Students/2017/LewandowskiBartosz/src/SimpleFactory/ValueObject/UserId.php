<?php

namespace Blewandowski\SimpleFactory\ValueObject;

use Ramsey\Uuid\Uuid;

class UserId
{
    private $id;

    protected function __construct(Uuid $uuid = null)
    {
        if(!$uuid) {
            $uuid =  Uuid::uuid1()->toString();
        }
        $this->id = $uuid;
    }
    
    public static function generate()
    {
        return new self();
    }

    public function __toString()
    {
        return $this->id;
    }
}