<?php

namespace Blewandowski\SimpleFactory\Entity;

use Blewandowski\SimpleFactory\ValueObject\Email;
use Blewandowski\SimpleFactory\ValueObject\Feature;
use Blewandowski\SimpleFactory\ValueObject\UserId;

abstract class AbstractUser
{
    private $id;

    private $name;

    private $email;

    private $accountType;

    private $active;

    private $createdAt;

    private $updatedAt;

    private $features = [];

    public function __construct(string $name, Email $email)
    {
        $this->id = UserId::generate();
        $this->name = $name;
        $this->email = $email;
        $this->createdAt = new \DateTimeImmutable();
    }

    public function getName()
    {
        return $this->name;
    }

    public function getEmail()
    {
        return $this->email;
    }

    public function activate()
    {
        $this->active = true;
        $this->updatedAt = new \DateTimeImmutable();
    }

    public function inactivate()
    {
        $this->active = true;
        $this->updatedAt = new \DateTimeImmutable();
    }

    public function isActive()
    {
        return $this->active;
    }

    public function addFeature(Feature $feature)
    {
        $this->features[] = $feature;
        $this->updatedAt = new \DateTimeImmutable();
        return $this;
    }

    public function getFeatures()
    {
        return $this->features;
    }

    public function getCreatedAt()
    {
        return $this->createdAt;
    }

    public function getUpdatedAt()
    {
        return $this->updatedAt;
    }
}