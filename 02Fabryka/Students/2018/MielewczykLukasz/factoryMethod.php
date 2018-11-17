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
			{
				self::$instance = new CoffinFactory();
			}
			return self::$instance;
		}
		
		function makeEmptyCoffin($type)
        {
            switch($type)
            {
                case 'Wooden':
                    return new WoodenCoffin();
                    break;
 
                case 'Stone':
                    return new StoneCoffin();
                    break;
					
		        case 'Glass':
                    return new GlassCoffin();
                    break;
 
                default:
                    throw new ArgumentException();
            }
        }
		
		function makeWithOrnamentationCoffin($type)
        {
            switch($type)
            {
                case 'Wooden':
					$coffin = new WoodenCoffin();
					$coffin->setOrnamentation(['Oak', 'Pine']);
                    return $coffin;
                    break;
 
                case 'Stone':
					$coffin = new StoneCoffin();
					$coffin->setOrnamentation(['Brick', 'Monument']);
                    return $coffin;
                    break;
					
		        case 'Glass':
					$coffin = new GlassCoffin();
					$coffin->setOrnamentation(['Bottle', 'Aggregate']);
                    return $coffin;
                    break;
 
                default:
                    throw new ArgumentException();
            }
        }
		
		function makeWithWreathCoffin($type)
        {
            switch($type)
            {
                case 'Wooden':
					$coffin = new WoodenCoffin();
					$coffin->setWreath('Black');
                    return $coffin;
                    break;
 
                case 'Stone':
					$coffin = new StoneCoffin();
					$coffin->setWreath('Colour');
                    return $coffin;
                    break;
					
		        case 'Glass':
					$coffin = new GlassCoffin();
					$coffin->setWreath('White');
                    return $coffin;
                    break;
 
                default:
                    throw new ArgumentException();
            }
        }
		
		function makeWithCorpseCoffin($type)
        {
            switch($type)
            {
                case 'Wooden':
					$coffin = new WoodenCoffin();
					$coffin->setCorpse('Corpse dressed in black clothes');
                    return $coffin;
                    break;
 
                case 'Stone':
					$coffin = new StoneCoffin();
					$coffin->setCorpse('Corpse dressed in black clothes');
                    return $coffin;
                    break;
					
		        case 'Glass':
					$coffin = new GlassCoffin();
					$coffin->setCorpse('Corpse dressed in black clothes');
                    return $coffin;
                    break;
 
                default:
                    throw new ArgumentException();
            }
        }
		
		function makeDeluxeCoffin($type)
        {
            switch($type)
            {
                case 'Wooden':
					$coffin = new WoodenCoffin();
					$coffin->setOrnamentation(['Oak', 'Pine']);
					$coffin->setWreath('Black');
					$coffin->setCorpse('Corpse dressed in black clothes');
                    return $coffin;
                    break;
 
                case 'Stone':
					$coffin = new StoneCoffin();
					$coffin->setOrnamentation(['Brick', 'Monument']);
					$coffin->setWreath('Colour');
					$coffin->setCorpse('Corpse dressed in black clothes');
                    return $coffin;
                    break;
					
		        case 'Glass':
					$coffin = new GlassCoffin();
					$coffin->setOrnamentation(['Bottle', 'Aggregate']);
					$coffin->setWreath('White');
					$coffin->setCorpse('Corpse dressed in black clothes');
                    return $coffin;
                    break;
 
                default:
                    throw new ArgumentException();
            }
        }
    }
?>