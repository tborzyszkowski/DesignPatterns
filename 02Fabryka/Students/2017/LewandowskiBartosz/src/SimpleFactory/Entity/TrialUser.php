<?php
namespace Blewandowski\SimpleFactory\Entity;

use Blewandowski\SimpleFactory\ValueObject\Feature;
use Blewandowski\SimpleFactory\ValueObject\Email;

class TrialUser extends AbstractUser
{
    public function __construct($name, Email $email)
    {
        parent::__construct($name, $email);

        $this->activate();
        $this
            ->addFeature(new Feature("Notatki", "Zarządzanie notatkami"))
            ->addFeature(new Feature("Wydarzenia", "Zarządzanie wydarzeniami"))
            ->addFeature(new Feature("Email", "Własna skrzynka pocztowa"))
            ->addFeature(new Feature("Klienci", "Zarządzanie klientami"));
    }
}