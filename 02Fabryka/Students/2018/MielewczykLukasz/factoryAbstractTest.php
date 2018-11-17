#!/usr/bin/php

<?php
	require_once('factoryAbstract.php');
	use PHPUnit\Framework\TestCase;
	
	class FactoryTest extends TestCase
	{
		public function testFactoryWooden()
		{
			$factory = WoodenCoffinFactory::getInstance();
			$factory2 = WoodenCoffinFactory::getInstance();
			
			$this->assertEquals(spl_object_hash($factory), spl_object_hash($factory2));
			
			$coffin = $factory->makeEmptyCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithOrnamentationCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithWreathCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithCorpseCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeDeluxeCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		public function testFactoryStone()
		{
			$factory = StoneCoffinFactory::getInstance();
			$factory2 = StoneCoffinFactory::getInstance();
			
			$this->assertEquals(spl_object_hash($factory), spl_object_hash($factory2));
			
			$coffin = $factory->makeEmptyCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithOrnamentationCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithWreathCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithCorpseCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeDeluxeCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		public function testFactoryGlass()
		{
			$factory = GlassCoffinFactory::getInstance();
			$factory2 = GlassCoffinFactory::getInstance();
			
			$this->assertEquals(spl_object_hash($factory), spl_object_hash($factory2));
			
			$coffin = $factory->makeEmptyCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithOrnamentationCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithWreathCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeWithCorpseCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(is_null($coffin->getOrnamentation()));
			$this->assertTrue(is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
			
			$coffin = $factory->makeDeluxeCoffin();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
	}
?>