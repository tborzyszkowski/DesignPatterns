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

	class StoneCoffinBuilder implements ICoffinBuilder
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

	class GlassCoffinBuilder implements ICoffinBuilder
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
	
	$builderW = new WoodenCoffinBuilder();
	$builderS = new StoneCoffinBuilder();
	$builderG = new GlassCoffinBuilder();
	$coffin1 = $builderW->corpse()->ornamentation()->build();
	$coffin2 = $builderW->wreath()->build();
	$coffin3 = $builderW->corpse()->ornamentation()->wreath()->build();
	$coffin4 = $builderW->corpse()->build();
	$coffin5 = $builderW->corpse()->ornamentation()->build();
	$coffin6 = $builderW->build();
	$coffin7 = $builderS->corpse()->ornamentation()->wreath()->build();
	$coffin8 = $builderS->wreath()->build();
	$coffin9 = $builderS->corpse()->ornamentation()->build();
	$coffin10 = $builderS->corpse()->build();
	$coffin11 = $builderS->corpse()->ornamentation()->wreath()->build();
	$coffin12 = $builderS->corpse()->wreath()->build();
	$coffin13 = $builderG->corpse()->ornamentation()->build();
	$coffin14 = $builderG->wreath()->build();
	$coffin15 = $builderG->corpse()->ornamentation()->wreath()->build();
	$coffin16 = $builderG->corpse()->ornamentation()->build();
	$coffin17 = $builderG->corpse()->ornamentation()->wreath()->build();
	$coffin18 = $builderG->build();
?>