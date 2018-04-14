<?php
	interface CoffinBuilder 
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

	class WoodenCoffinBuilder implements CoffinBuilder
	{
		private $coffin = NULL;
		
		function __construct()
		{
			$this->coffin = new WoodenCoffin();
		}
		
		function ornamentation()
		{
			$this->coffin->setOrnamentation(['Oak', 'Pine']);
			return $this;
		}
		function wreath()
		{
			$this->coffin->setWreath('Black');
			return $this;
		}
		function corpse()
		{
			$this->coffin->setCorpse('Corpse dressed in black clothes');
			return $this;
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

	class StoneCoffinBuilder implements CoffinBuilder
	{
		private $coffin = NULL;
		
		function __construct()
		{
			$this->coffin = new StoneCoffin();
		}
		
		function ornamentation()
		{
			$this->coffin->setOrnamentation(['Brick', 'Monument']);
			return $this;
		}
		function wreath()
		{
			$this->coffin->setWreath('Colour');
			return $this;
		}
		function corpse()
		{
			$this->coffin->setCorpse('Corpse dressed in black clothes');
			return $this;
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

	class GlassCoffinBuilder implements CoffinBuilder
	{
		private $coffin = NULL;
		
		function __construct()
		{
			$this->coffin = new GlassCoffin();
		}
		
		function ornamentation()
		{
			$this->coffin->setOrnamentation(['Oak', 'Pine']);
			return $this;
		}
		function wreath()
		{
			$this->coffin->setWreath('Black');
			return $this;
		}
		function corpse()
		{
			$this->coffin->setCorpse('Corpse dressed in black clothes');
			return $this;
		}
		function build()
		{
			return $this->coffin;
		}
	}
?>