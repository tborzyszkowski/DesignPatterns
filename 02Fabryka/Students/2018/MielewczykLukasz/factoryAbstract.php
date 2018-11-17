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
		private function __construct()
		{
		}
		
		private static $instance;
		
		static function getInstance()
		{
			if(self::$instance === null)
				self::$instance = new WoodenCoffinFactory();
			return self::$instance;
		}

		function makeEmptyCoffin()
		{
			return new WoodenCoffin();
		}
		
		function makeWithOrnamentationCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setOrnamentation(['Oak', 'Pine']);
			return $coffin;
		}
		
		function makeWithWreathCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setWreath('Black');
			return $coffin;
		}
		
		function makeWithCorpseCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
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
		private function __construct()
		{
		}
		
		private static $instance;
		
		static function getInstance()
		{
			if(self::$instance === null)
				self::$instance = new StoneCoffinFactory();
			return self::$instance;
		}
		
		function makeEmptyCoffin()
		{
			return new StoneCoffin();
		}
		
		function makeWithOrnamentationCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setOrnamentation(['Brick', 'Monument']);
			return $coffin;
		}
		
		function makeWithWreathCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setWreath('Colour');
			return $coffin;
		}
		
		function makeWithCorpseCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
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
			
		private function __construct()
		{
		}
		
		private static $instance;
		
		static function getInstance()
		{
			if(self::$instance === null)
				self::$instance = new GlassCoffinFactory();
			return self::$instance;
		}
		
		function makeEmptyCoffin()
		{
			return new GlassCoffin();
		}
		
		function makeWithOrnamentationCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setOrnamentation(['Bottle', 'Aggregate']);
			return $coffin;
		}
		
		function makeWithWreathCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setWreath('White');
			return $coffin;
		}
		
		function makeWithCorpseCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
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
?>