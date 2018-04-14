#!/usr/bin/php

<?php
	require_once('builderSimple.php');
	use PHPUnit\Framework\TestCase;
	
	class BuilderTest extends TestCase
	{
		public function testWoodenBuilder()
		{
			$builder = new WoodenCoffinBuilder();
			$builder->corpse();
			$builder->ornamentation();
			$builder->wreath();
			$coffin = $builder->build();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		public function testStoneBuilder()
		{
			$builder = new StoneCoffinBuilder();
			$builder->corpse();
			$builder->ornamentation();
			$builder->wreath();
			$coffin = $builder->build();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
		
		public function testGlassBuilder()
		{
			$builder = new GlassCoffinBuilder();
			$builder->corpse();
			$builder->ornamentation();
			$builder->wreath();
			$coffin = $builder->build();
			$this->assertTrue(!is_null($coffin));
			$this->assertTrue(!is_null($coffin->getMaterial()));
			$this->assertTrue(!is_null($coffin->getOrnamentation()));
			$this->assertTrue(!is_null($coffin->getWreath()));
			$this->assertTrue(!is_null($coffin->getCorpse()));
		}
	}
?>