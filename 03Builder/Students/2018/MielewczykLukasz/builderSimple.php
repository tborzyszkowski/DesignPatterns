<?php
	interface ICoffinBuilder 
	{
		public function ornamentation();
		public function wreath();
		public function corpse();
		public function build();
	}
	
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

	class WoodenCoffinBuilder implements ICoffinBuilder
	{
		private $coffin = NULL;
		
		function __construct()
		{
			$this->coffin = new WoodenCoffin();
		}
		
		function ornamentation()
		{
			$this->coffin->setOrnamentation(['Oak', 'Pine']);
		}
		function wreath()
		{
			$this->coffin->setWreath('Black');
		}
		function corpse()
		{
			$this->coffin->setCorpse('Corpse dressed in black clothes');
		}
		function build()
		{
			return $this->coffin;
		}
	}
	
	class StoneCoffin extends Coffin
	{
		function __construct()
		{
			$this->setMaterial('Stone');
		}
	}

	class StoneCoffinBuilder implements ICoffinBuilder
	{
		private $coffin = NULL;
		
		function __construct()
		{
			$this->coffin = new GlassCoffin();
		}
		
		function ornamentation()
		{
			$this->coffin->setOrnamentation(['Brick', 'Monument']);
		}
		function wreath()
		{
			$this->coffin->setWreath('Colour');
		}
		function corpse()
		{
			$this->coffin->setCorpse('Corpse dressed in black clothes');
		}
		function build()
		{
			return $this->coffin;
		}
	}
	
	class GlassCoffin extends Coffin
	{
		function __construct()
		{
			$this->setMaterial('Glass');
		}
	}

	class GlassCoffinBuilder implements ICoffinBuilder
	{
		private $coffin = NULL;
		
		function __construct()
		{
			$this->coffin = new GlassCoffin();
		}
		
		function ornamentation()
		{
			$this->coffin->setOrnamentation(['Bottle', 'Aggregate']);
		}
		function wreath()
		{
			$this->coffin->setWreath('White');
		}
		function corpse()
		{
			$this->coffin->setCorpse('Corpse dressed in black clothes');
		}
		function build()
		{
			return $this->coffin;
		}
	}
?>