<?php
namespace Blewandowski\SimplePrototype;

abstract class BookPrototype
{
    private $id;
    
    private $title;
    
    private $author;
    
    public function getId()
    {
        return $this->id;
    }
    
    public function setId($id)
    {
        $this->id = $id;
        return $this;
    }
    
    public function getTitle()
    {
        return $this->title;
    }
    
    public function setTitle($title)
    {
        $this->title = $title;
        return $this;
    }
    
    public function getAuthor()
    {
        return $this->author;
    }
    
    public function setAuthor($author)
    {
        $this->author = $author;
        return $this;
    }
    
    abstract public function __clone();
    
    public function __toString()
    {
        return serialize($this);
    }
}