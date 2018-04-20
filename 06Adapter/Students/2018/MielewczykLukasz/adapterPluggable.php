<?php
	interface ICoffinAdapter
	{
		public function  getWoodenCoffin();
		public function  getGlassCoffin();
	}
	class NewCoffinWooden
	{
		public function woodenCoffin()
		{
			return "Coffin Wooden";
		}
	}
	class NewCoffinGlass
	{
		public function glassCoffin()
		{
			return "Coffin Glass";
		}
	}
	class CoffinAdapter implements ICoffinAdapter
	{
		public function getWoodenCoffin() 
		{
			$coffin = new NewCoffinWooden();
			$coffin->woodenCoffin();
		}
		public function getGlassCoffin() 
		{
			$coffin = new NewCoffinGlass();
			$coffin->glassCoffin();
		}
	}
	 
	$client = new CoffinAdapter();
	echo $client->getWoodenCoffin();
	echo $client->getGlassCoffin(); 
?>