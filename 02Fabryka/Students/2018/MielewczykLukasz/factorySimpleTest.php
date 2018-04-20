#!/usr/bin/php

<?php
	require_once('factorySimple.php');
	use PHPUnit\Framework\TestCase;
	
	class FactoryTest extends TestCase
	{
		public function testFactoryWooden()
		{
			$factory = CoffinFactory::getInstance();
			$factory2 = CoffinFactory::getInstance();
			
			$this->assertEquals(spl_object_hash($factory), spl_object_hash($factory2));
			
			$coffin = $factory->getWoodenEmptyCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getWoodenWithOrnamentationCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getWoodenWithWreathCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getWoodenWithCorpseCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
			
			$coffin = $factory->getWoodenDeluxeCoffin();
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
			
			$coffin = $factory->getStoneEmptyCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getStoneWithOrnamentationCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getStoneWithWreathCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getStoneWithCorpseCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
			
			$coffin = $factory->getStoneDeluxeCoffin();
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
			
			$coffin = $factory->getGlassEmptyCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getGlassWithOrnamentationCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getGlassWithWreathCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->getGlassWithCorpseCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
			
			$coffin = $factory->getGlassDeluxeCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
	}
?>