using System;
using System.Linq;
using System.Reflection;
using DesignPatternsPrototype.BaseShallowAndDeep.ConcretePrototype;
using DesignPatternsPrototype.DeeperData;
using DesignPatternsPrototype.DeepWithReflection;

namespace DesignPatternsPrototype.BaseShallowAndDeep.Client
{
    [Serializable()]
    public class ZooManager
    {
        public void ShallowCat()
        {
            PrototypeAnimalCat cat = new PrototypeAnimalCat
            {
                Name = "Kitku",
                Barcode = "999",
                Details =
                {
                    Height = 555,
                    Weight = 666
                }
            };

            Console.WriteLine("\n Shallow Copy:\nOriginal animal stats:");
            Console.WriteLine($"\nName: {cat.Name}\n Barcode: {cat.Barcode}\n DeeperData:Details.Height: {cat.Details.Height}\n DeeperData:Details.Weight: {cat.Details.Weight} ");

            PrototypeAnimalCat animalToSave = cat.Clone();

            Console.WriteLine("\n Copy of animal to save on disk:");
            Console.WriteLine($"\nName: {animalToSave.Name}\n Barcode: {animalToSave.Barcode}\n DeeperData:Details.Height:  {animalToSave.Details.Height}\n DeeperData:Details.Weight: {animalToSave.Details.Weight}");

            animalToSave.Name = "New Kitku name";
            animalToSave.Barcode = "333";
            animalToSave.Details.Height = 7777;
            animalToSave.Details.Weight = 8888;

            Console.WriteLine("\n Changed Data\nOriginal animal stats:");
            Console.WriteLine($"\nName: {cat.Name}\n Barcode: {cat.Barcode}\n DeeperData:Details.Height: {cat.Details.Height}\n DeeperData:Details.Weight: {cat.Details.Weight}");
            Console.WriteLine("\nCopy of animal to save on disk:");
            Console.WriteLine($"\nName: {animalToSave.Name}\n Barcode: {animalToSave.Barcode}\n DeeperData:Details.Height: {animalToSave.Details.Height}\n DeeperData:Details.Weight: {animalToSave.Details.Weight} ");
        }

        public void DeepDogSerializable()
        {
            PrototypeAnimalDog dog = new PrototypeAnimalDog
            {
                Details = new AdditionalDetails
                {
                    Height = 777,
                    Weight = 888
                },
                Name = "Doggo",
                Barcode = "333"
            };

            PrototypeAnimalDog c3 = new PrototypeAnimalDog();
            c3 = dog.DeepCopy();
            dog.Name = "NEEEEWW DOGOO";
            dog.Barcode = "wuuf";
            dog.Details.Height = 456;
            dog.Details.Height = 789;
            dog.Details.DeeperData.Data = "new data 3 level";

            Console.WriteLine("\n--------------------------------\nChanged Data\n Original animal stats:");
            Console.WriteLine($"\nName: {dog.Name}\n Barcode: {dog.Barcode}\n Height {dog.Details.Height}\n Weight {dog.Details.Weight}\n DeeperData  { dog.Details.DeeperData.Data} ");

            Console.WriteLine("\nCopy of animal to save on disk:");
            Console.WriteLine($"\nName: {c3.Name}\n Barcode: {c3.Barcode}\n Height {c3.Details.Height}\n Weight { c3.Details.Weight}\n DeeperData { c3.Details.DeeperData.Data} ");
        }

        public void DeepDogWithReflection()
        {
            PrototypeAnimalDog dog = new PrototypeAnimalDog
            {
                Details = new AdditionalDetails
                {
                    Height = 777,
                    Weight = 888
                },
                Name = "Doggo",
                Barcode = "333"
            };

            PrototypeAnimalDog doggoWithReflection = (PrototypeAnimalDog) dog.CloneProcedure();

            dog.Details.Height = 111;
            dog.Details.Weight = 222;
            dog.Name = "first_dogi";
            dog.Barcode = "ciap ciap";

            Console.WriteLine("\n--------------------------------\n  Deep Dog With Reflection\n Original animal stats:");
            Console.WriteLine($"\nName: {dog.Name}\n Barcode: {dog.Barcode}\n Charisma {dog.Details.Height}\n Details.Height: {dog.Details.Weight}\n DeeperData {dog.Details.DeeperData.Data} ");

            Console.WriteLine("\nCopy of animal to save on disk:");
            Console.WriteLine($"\nName: {doggoWithReflection.Name}\n Barcode: {doggoWithReflection.Barcode}\n Details.Height: {doggoWithReflection.Details.Height}\n Details.Weight " +
                              $"{doggoWithReflection.Details.Weight}\n Details.DeeperData.Data: { doggoWithReflection.Details.DeeperData.Data} ");

        }

  }
}
