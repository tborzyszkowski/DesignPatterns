#!/usr/bin/php

<?php
	require_once('builderFluet.php');
	use PHPUnit\Framework\TestCase;
	
	class BuilderTest extends TestCase
	{
		public function testWoodenBuilder()
		{
			$builder = new WoodenCoffinBuilder();
			$coffin = $builder->corpse()->ornamentation()->wreath()->build();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		public function testStoneBuilder()
		{
			$builder = new StoneCoffinBuilder();
			$coffin = $builder->corpse()->ornamentation()->wreath()->build();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		public function testGlassBuilder()
		{
			$builder = new GlassCoffinBuilder();
			$coffin = $builder->corpse()->ornamentation()->wreath()->build();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
	}
?>