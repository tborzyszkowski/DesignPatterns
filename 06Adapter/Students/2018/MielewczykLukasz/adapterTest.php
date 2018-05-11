#!/usr/bin/php

<?php
	require_once('adapter.php');
	use PHPUnit\Framework\TestCase;
	
	class AdapterTest extends TestCase
	{
		public function testHomeBurial()
		{
			$adapter = new Adapter(new HomeBurial());
			$corpse = $adapter->Request()('Jan', 'Kowalski');
			$this->assertTrue(!is_null($corpse));
			$this->assertEquals('Jan', $corpse->getFirstName());
			$this->assertEquals('Kowalski', $corpse->getLastName());
			$this->assertEquals('Bury in the garden', $corpse->getBurial());
		}
		
		public function testFuneralHomeBurial()
		{
			$adapter = new Adapter(new FuneralHomeBurial());
			$corpse = $adapter->Request()('Jan', 'Kowalski');
			$this->assertTrue(!is_null($corpse));
			$this->assertEquals('Jan', $corpse->getFirstName());
			$this->assertEquals('Kowalski', $corpse->getLastName());
			$this->assertEquals('Buried in a coffin in the cemetery', $corpse->getBurial());
		}
		
		public function testChangeRequest()
		{
			$adapter = new Adapter(new FuneralHomeBurial());
			$adapter->changeRequest('HomeBurial::getCorpse');
			$corpse = $adapter->Request()('Jan', 'Kowalski');
			$this->assertTrue(!is_null($corpse));
			$this->assertEquals('Jan', $corpse->getFirstName());
			$this->assertEquals('Kowalski', $corpse->getLastName());
			$this->assertEquals('Bury in the garden', $corpse->getBurial());
		}
	}
?>