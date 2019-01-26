<?php
/**
 * Created by PhpStorm.
 * User: krzemson
 * Date: 25.01.2019
 * Time: 02:32
 */

namespace App;


class PriceForNewClient implements Price
{
    public function count($value)
    {
        return 1.20 * $value;
    }

}