<?php
	interface ICoffinPrototype
	{
		function shallowCopy();
		function deepCopy();
	}
	
	class Coffin implements ICoffinPrototype
	{
		private $material = NULL;
		private $corpse = NULL;
		
		function setMaterial($material)
		{
		  $this->material = $material;
		}
		
		function setCorpse($person)
		{
		  $this->corpse = $person;
		}
		
		function getMaterial()
		{
		  return $this->material;
		}
		
		function getCorpse()
		{
		  return $this->corpse;
		}
		
		private function deepCopySubClass($object)
		{
			$class = get_class($object);
			$copy = new $class();
			$set = 'set';
			$values = $object->getObjectVars();
			foreach ($values as $key => $val)
			{
				$method = $set.$key;
				if(!is_object($val))
					$copy->$method($val);
				else
					$copy->$method($this->deepCopySubClass($val));
				$set = 'set';
			}
			return $copy;
		}
		
		function deepCopy()
		{
			$copy = new Coffin();
			$values = get_object_vars($this);
			foreach ($values as $key => $val)
			{
				if(!is_object($val))
					$copy->$key = $val;
				else
					$copy->$key = $this->deepCopySubClass($val);
			}
			return $copy;
		}
		
		function shallowCopy()
		{
			$copy = new Coffin();
			$values = get_object_vars($this);
			foreach ($values as $key => $val)
			{
				if(!is_object($val))
					$copy->$key = $val;
			}
			return $copy;
		}
	}

	class Person 
	{
		private $firstName = NULL;
		private $lastName = NULL;
		private $address = NULL;

		function setFirstName($firstName)
		{
		  $this->firstName = $firstName;
		}
		
		function setLastName($lastName)
		{
		  $this->lastName = $lastName;
		}
		
		function setAddress($address)
		{
		  $this->address = $address;
		}
		
		function getFirstName()
		{
		  return $this->firstName;
		}
		
		function getLastName()
		{
		  return $this->lastName;
		}
		
		function getAddress()
		{
		  return $this->address;
		}
		
		function getObjectVars()
		{
			return get_object_vars($this);
		}
	}
	
	class Address 
	{
		private $city = NULL;
		private $street = NULL;
		private $houseNumber = NULL;
		
		function setCity($city)
		{
		  $this->city = $city;
		}
		
		function setStreet($street)
		{
		  $this->street = $street;
		}
		
		function setHouseNumber($houseNumber)
		{
		  $this->houseNumber = $houseNumber;
		}
		
		function getCity()
		{
		  return $this->city;
		}
		
		function getStreet()
		{
		  return $this->street;
		}

		function getHouseNumber()
		{
		  return $this->houseNumber;
		}

		function getObjectVars()
		{
			return get_object_vars($this);
		}
	}
?>