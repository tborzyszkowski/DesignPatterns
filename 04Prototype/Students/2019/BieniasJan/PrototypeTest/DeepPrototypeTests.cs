using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.DeepPrototype;

namespace PrototypeTest
{
    [TestClass]
    public class DeepPrototypeTests
    {
        Restaurant restaurant;
        Restaurant clonedRestaurant;

        Restaurant reflectionClonedRestaurant;

        [TestInitialize]
        public void Initialize()
        {
            restaurant = new Restaurant(new Kitchen(new Chef(new Assistant())));
            clonedRestaurant = restaurant.DeepClone() as Restaurant;

            reflectionClonedRestaurant = restaurant.DeepCloneByReflection() as Restaurant;
        }

        [TestMethod]
        public void RestaurantsAreNotEqual()
        {
            Assert.AreNotEqual(restaurant, clonedRestaurant);

            Assert.AreNotEqual(restaurant, reflectionClonedRestaurant);
        }

        [TestMethod]
        public void KitchensOfBothRestaurantsAreNotEqual()
        {
            var kitchen = restaurant.Kitchen;
            var clonedKitchen = clonedRestaurant.Kitchen;
            Assert.AreNotEqual(kitchen, clonedKitchen);

            var reflectionClonedKitchen = reflectionClonedRestaurant.Kitchen;
            Assert.AreNotEqual(kitchen, reflectionClonedKitchen);
        }

        [TestMethod]
        public void ChefsOfKitchensOfBothRestaurantsAreNotEqual()
        {
            var chef = restaurant.Kitchen.Chef;
            var clonedChef = clonedRestaurant.Kitchen.Chef;
            Assert.AreNotEqual(chef, clonedChef);

            var reflectionClonedChef = reflectionClonedRestaurant.Kitchen.Chef;
            Assert.AreNotEqual(chef, reflectionClonedChef);
        }

        [TestMethod]
        public void AssistantsOfChefsOfKitchensOfBothRestaurantsAreNotEqual()
        {
            var assistant = restaurant.Kitchen.Chef.Assistant;
            var clonedAssistant = clonedRestaurant.Kitchen.Chef.Assistant;
            Assert.AreNotEqual(assistant, clonedAssistant);

            var reflectionClonedAssistant = reflectionClonedRestaurant.Kitchen.Chef.Assistant;
            Assert.AreNotEqual(assistant, reflectionClonedAssistant);
        }

        [TestCleanup]
        public void Cleanup()
        {
            restaurant = null;
            clonedRestaurant = null;

            reflectionClonedRestaurant = null;
        }
    }
}
