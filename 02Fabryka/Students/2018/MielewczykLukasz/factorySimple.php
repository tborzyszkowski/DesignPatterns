<?php 
	abstract class Coffin 
	{
		private $material = NULL;
		private $ornamentation = NULL;
		private $wreath = NULL;
		private $corpse = NULL;
		
		public function __construct()
		{
		}
		
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
 
    class CoffinFactory
    {
		private function __construct()
		{
		}
		
		private static $instance;
		
		static function getInstance()
		{
			if(self::$instance === null)
				self::$instance = new CoffinFactory();
			return self::$instance;
		}
		
		function getWoodenEmptyCoffin()
		{
			return new WoodenCoffin();
		}
		
		function getWoodenWithOrnamentationCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setOrnamentation(['Oak', 'Pine']);
			return $coffin;		
		}

		function getWoodenWithWreathCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setWreath('Black');
			return $coffin;
		}
		
		function getWoodenWithCorpseCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
		
		function getWoodenDeluxeCoffin()
		{
			$coffin = new WoodenCoffin();
			$coffin->setOrnamentation(['Oak', 'Pine']);
			$coffin->setWreath('Black');
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
		
		function getStoneEmptyCoffin()
		{
			return new StoneCoffin();
		}
		
		function getStoneWithOrnamentationCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setOrnamentation(['Brick', 'Monument']);
			return $coffin;
		}
		
		function getStoneWithWreathCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setWreath('Colour');
			return $coffin;
		}
		
		function getStoneWithCorpseCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
		
		function getStoneDeluxeCoffin()
		{
			$coffin = new StoneCoffin();
			$coffin->setOrnamentation(['Brick', 'Monument']);
			$coffin->setWreath('Colour');
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
		
		function getGlassEmptyCoffin()
		{
			return new GlassCoffin();
		}
		
		function getGlassWithOrnamentationCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setOrnamentation(['Bottle', 'Aggregate']);
			return $coffin;
		}
		
		function getGlassWithWreathCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setWreath('White');
			return $coffin;
		}
		
		function getGlassWithCorpseCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
		
		function getGlassDeluxeCoffin()
		{
			$coffin = new GlassCoffin();
			$coffin->setOrnamentation(['Bottle', 'Aggregate']);
			$coffin->setWreath('White');
			$coffin->setCorpse('Corpse dressed in black clothes');
			return $coffin;
		}
    }
?>