<?php
/**
 * Created by PhpStorm.
 * User: krzemson
 * Date: 25.01.2019
 * Time: 02:33
 */

namespace App;


class PriceForWholesaler implements Price
{
    public function count($value)
    {
        return 1.10 * $value;
    }

}