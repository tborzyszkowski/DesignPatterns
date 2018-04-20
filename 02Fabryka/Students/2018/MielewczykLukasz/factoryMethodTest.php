#!/usr/bin/php

<?php
	require_once('factoryMethod.php');
	use PHPUnit\Framework\TestCase;
	
	class FactoryTest extends TestCase
	{
		public function testFactoryWooden()
		{
			$factory = CoffinFactory::getInstance();
			$factory2 = CoffinFactory::getInstance();
			
			$this->assertEquals(spl_object_hash($factory), spl_object_hash($factory2));
			
			$coffin = $factory->makeEmptyCoffin('Wooden');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithOrnamentationCoffin('Wooden');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithWreathCoffin('Wooden');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithCorpseCoffin('Wooden');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));

			$coffin = $factory->makeDeluxeCoffin('Wooden');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		
		public function testFactoryStone()
		{
			$factory = CoffinFactory::getInstance();
			$factory2 = CoffinFactory::getInstance();
			
			$this->assertEquals(spl_object_hash($factory), spl_object_hash($factory2));
			
			$coffin = $factory->makeEmptyCoffin('Stone');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithOrnamentationCoffin('Stone');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithWreathCoffin('Stone');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithCorpseCoffin('Stone');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));

			$coffin = $factory->makeDeluxeCoffin('Stone');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		public function testFactoryGlass()
		{
			$factory = CoffinFactory::getInstance();
			$factory2 = CoffinFactory::getInstance();
			
			$this->assertEquals(spl_object_hash($factory), spl_object_hash($factory2));
			
			$coffin = $factory->makeEmptyCoffin('Glass');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithOrnamentationCoffin('Glass');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithWreathCoffin('Glass');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithCorpseCoffin('Glass');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeDeluxeCoffin('Glass');
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
	}
?>