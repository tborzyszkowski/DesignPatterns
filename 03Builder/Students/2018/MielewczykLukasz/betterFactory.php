<?php
	abstract class Coffin 
	{
		private $material = NULL;
		private $ornamentation = NULL;
		private $wreath = NULL;
		private $corpse = NULL;
		
		function setMaterial($material)
		{
		  $this->material = $material;
		}
		function setOrnamentation($ornamentation)
		{
		  $this->ornamentation = $ornamentation;
		}
		function setWreath($wreath)
		{
		  $this->wreath = $wreath;
		}
		function setCorpse($corpse)
		{
		   $this->corpse = $corpse;
		}
		function getMaterial()
		{
		  return $this->material;
		}
		function getOrnamentation()
		{
		  return $this->ornamentation;
		}
		function getWreath()
		{
		  return $this->wreath;
		}
		function getCorpse()
		{
		   return $this->corpse;
		}
	}
	
	class WoodenCoffin extends Coffin
	{
		function __construct()
		{
			$this->setMaterial('Wood');
		}
	}
	
	class StoneCoffin extends Coffin
	{
		function __construct()
		{
			$this->setMaterial('Stone');
		}
	}

	class GlassCoffin extends Coffin
	{
		function __construct()
		{
			$this->setMaterial('Glass');
		}
	}
	
	interface ICoffinFactory 
	{
		function makeEmptyCoffin();
		function makeWithOrnamentationCoffin();
		function makeWithWreathCoffin();
		function makeWithCorpseCoffin();
		function makeDeluxeCoffin();
	}
	
	class WoodenCoffinFactory implements ICoffinFactory
	{
		public function __construct()
		{
		}

		function makeEmptyCoffin()
		{
			return new WoodenCoffin();
		}
		
		function makeDeluxeCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setOrnamentation(['Oak', 'Pine']);
			$coffin->setWreath('Black');
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
	}
	
	class StoneCoffinFactory implements ICoffinFactory
	{
		public function __construct()
		{
		}
		
		function makeEmptyCoffin()
		{
			return new StoneCoffin();
		}
		
		function makeDeluxeCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setOrnamentation(['Brick', 'Monument']);
			$coffin->setWreath('Colour');
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
	}
	
	class GlassCoffinFactory implements ICoffinFactory
	{
			
		public function __construct()
		{
		}
		
		function makeEmptyCoffin()
		{
			return new GlassCoffin();
		}
		
		
		function makeDeluxeCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setOrnamentation(['Bottle', 'Aggregate']);
			$coffin->setWreath('White');
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
	}
	
	$factoryW = new WoodenCoffinFactory();
	$factoryS = new StoneCoffinFactory();
	$factoryG = new GlassCoffinFactory();
	$coffin1 = $factoryW->makeEmptyCoffin();
	$coffin2 = $factoryW->makeDeluxeCoffin();
	$coffin3 = $factoryW->makeEmptyCoffin();
	$coffin4 = $factoryW->makeDeluxeCoffin();
	$coffin5 = $factoryW->makeEmptyCoffin();
	$coffin6 = $factoryW->makeDeluxeCoffin();
	$coffin7 = $factoryS->makeDeluxeCoffin();
	$coffin8 = $factoryS->makeEmptyCoffin();
	$coffin9 = $factoryS->makeDeluxeCoffin();
	$coffin10 = $factoryS->makeDeluxeCoffin();
	$coffin11 = $factoryS->makeEmptyCoffin();
	$coffin12 = $factoryS->makeDeluxeCoffin();
	$coffin13 = $factoryG->makeDeluxeCoffin();
	$coffin14 = $factoryG->makeEmptyCoffin();
	$coffin15 = $factoryG->makeDeluxeCoffin();
	$coffin16 = $factoryG->makeEmptyCoffin();
	$coffin17 = $factoryG->makeDeluxeCoffin();
	$coffin18 = $factoryG->makeEmptyCoffin();
?>