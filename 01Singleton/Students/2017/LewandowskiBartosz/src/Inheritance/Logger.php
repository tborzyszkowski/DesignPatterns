<?php

namespace Blewandowski\Inheritance;


class Logger extends Singleton
{
    public function writeToSyslog(string $string)
    {
        return "Syslog: ".$string;
    }
}