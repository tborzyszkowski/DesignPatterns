<?php
namespace Blewandowski\SimpleFactory\Entity;

use Blewandowski\SimpleFactory\ValueObject\Feature;
use Blewandowski\SimpleFactory\ValueObject\Email;

class PremiumUser extends AbstractUser
{
    public function __construct($name, Email $email)
    {
        parent::__construct($name, $email);

        $this->activate();
        $this
            ->addFeature(new Feature("Opłaty", "Moduł do opłacania abonamentu za usługę"))
            ->addFeature(new Feature("Notatki", "Zarządzanie notatkami"))
            ->addFeature(new Feature("Wydarzenia", "Zarządzanie wydarzeniami"))
            ->addFeature(new Feature("Email", "Własna skrzynka pocztowa"))
            ->addFeature(new Feature("Klienci", "Zarządzanie klientami"))
            ->addFeature(new Feature("Integracje", "API do integracji z usługami zewnętrznymi"))
            ->addFeature(new Feature("Import/Export danych z plików", "Tworzenie magazynów danych z plików XML, JSON, CSV, XSL, XSLT"))
            ->addFeature(new Feature("5 TB CLOUD", "Przestrzeń dyskowa w chmurze"));
    }
}