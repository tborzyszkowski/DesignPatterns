<?php

namespace Blewandowski\Inheritance;


class ExtendedLogger extends Logger
{
    public function writeToRedis($string)
    {
        return "Redis: ".$string;
    }

    public function writeToElasticSearch($string)
    {
        return "ElasticSearch: ".$string;
    }
}