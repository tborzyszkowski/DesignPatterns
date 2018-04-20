#!/usr/bin/php

<?php
	require_once('prototype.php');
	use PHPUnit\Framework\TestCase;
		
	class PrototypeTest extends TestCase
	{
		public function testShallowCopy()
		{
			$address = new Address();
			$address->setCity('Gdansk');
			$address->setStreet('Polanki');
			$address->setHouseNumber(22);
			$person = new Person();
			$person->setFirstName('Jan');
			$person->setLastName('Kowalski');
			$person->setAddress($address);
			
			$originalCoffin = new Coffin();
			$originalCoffin->setMaterial('Woodden');
			$originalCoffin->setCorpse($person);
			
			$clonedCoffin = $originalCoffin->shallowCopy();

			$this->assertTrue($originalCoffin->getMaterial() === $clonedCoffin->getMaterial());
			$this->assertFalse($originalCoffin->getCorpse() === $clonedCoffin->getCorpse());
			$this->assertFalse(is_null($originalCoffin->getCorpse()));
			$this->assertTrue(is_null($clonedCoffin->getCorpse()));
		}
		
		public function testDeepCopy()
		{	
			$address = new Address();
			$address->setCity('Gdansk');
			$address->setStreet('Polanki');
			$address->setHouseNumber(22);
			$person = new Person();
			$person->setFirstName('Jan');
			$person->setLastName('Kowalski');
			$person->setAddress($address);
			
			$originalCoffin = new Coffin();
			$originalCoffin->setMaterial('Woodden');
			$originalCoffin->setCorpse($person);
			$originalCorpse = $originalCoffin->getCorpse();
			$originalAddress = $originalCoffin->getCorpse()->getAddress();
			
			$clonedCoffin = $originalCoffin->deepCopy();
			$clonedCorpse = $clonedCoffin->getCorpse();
			$clonedAddress = $clonedCoffin->getCorpse()->getAddress();
			
			$this->assertFalse(is_null($clonedCoffin->getCorpse()));
			$this->assertFalse(is_null($originalCoffin->getCorpse()));
			$this->assertFalse(is_null($clonedCoffin->getCorpse()->getAddress()));
			$this->assertFalse(is_null($originalCoffin->getCorpse()->getAddress()));

			$this->assertTrue($originalCorpse->getFirstName() === $clonedCorpse->getFirstName());
			$this->assertTrue($originalAddress->getCity() === $clonedAddress->getCity());
			
			$this->assertFalse(spl_object_hash($originalCorpse) === spl_object_hash($clonedCorpse));
			$this->assertFalse(spl_object_hash($originalAddress) === spl_object_hash($clonedAddress));
		}
	}
?>