<?php
	class Corpse
	{
		private $firstName = NULL;
		private $lastName = NULL;
		private $burial = NULL;
		
		function setFirstName($firstName)
		{
		  $this->firstName = $firstName;
		}
		function setLastName($lastName)
		{
		  $this->lastName = $lastName;
		}
		function setBurial($burial)
		{
		  $this->burial = $burial;
		}
		function getFirstName()
		{
		  return $this->firstName;
		}
		function getLastName()
		{
		  return $this->lastName;
		}
		function getBurial()
		{
		  return $this->burial;
		}
	}
	
	class HomeBurial
	{
		private $corpse;
		
		function __construct()
		{
		}
		
		function getCorpse($firstName, $lastName)
		{
			$corpse = new Corpse();
			$corpse->setFirstName($firstName);
			$corpse->setLastName($lastName);
			$corpse->setBurial('Bury in the garden');
			return $corpse;
		}
	}
	
	class FuneralHomeBurial
	{
		private $corpse;
		
		function __construct()
		{
		}
		
		function getFormFuneral($coffin)
		{
			switch ($coffin)
			{
				case 1:
					return 'Buried in a coffin';
					break;
				case 2:
					return 'Buried in a urn';
					break;
				default:
					return 'Buried in a coffin or urn';
					break;
			}
		}
	}
	
	class Adapter extends FuneralHomeBurial
	{
		private $request;
		
		function Request()
		{
		  return $this->request;
		}
		
		function getCorpse($firstName, $lastName)
		{
			$corpse = new Corpse();
			$corpse->setFirstName($firstName);
			$corpse->setLastName($lastName);
			$formFuneral = FuneralHomeBurial::getFormFuneral(true);
			$corpse->setBurial($formFuneral.' in the cemetery');
			return $corpse;
		}
		
		function __construct($obj)
		{
			switch (get_class($obj))
			{
				case 'HomeBurial':
					$this->request = 'HomeBurial::getCorpse';
					break;
				case 'FuneralHomeBurial':
					$this->request = 'Adapter::getCorpse';
					break;
			}
		}
		
		function changeRequest($function)
		{
			$this->request = $function;
		}
	}
?>