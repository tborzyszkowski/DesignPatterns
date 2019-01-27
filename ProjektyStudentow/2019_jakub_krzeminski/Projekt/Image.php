<?php


namespace App;


class Image implements HighResolutionImage
{
    private $options;
    public function __construct($options)
    {
        $this->options=$options;
        // generate image
    }
    public function display()
    {
        echo 'display image';
    }
}