using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype.ShallowPrototype;

namespace PrototypeTest
{
    [TestClass]
    public class PrototypeTestsTaskOne
    {
        Restaurant restaurant;
        Restaurant clonedRestaurant;

        [TestInitialize]
        public void Initialize()
        {
            restaurant = new Restaurant(new Kitchen(new Chef(new Assistant())));
            clonedRestaurant = restaurant.Clone() as Restaurant;
        }

        [TestMethod]
        public void RestaurantsAreNotEqual()
        {
            Assert.AreNotEqual(restaurant, clonedRestaurant);
        }

        [TestMethod]
        public void KitchensOfBothRestaurantsAreEqual()
        {
            var kitchen = restaurant.Kitchen;
            var clonedKitchen = clonedRestaurant.Kitchen; //"clonedKitchen"
            Assert.AreEqual(kitchen, clonedKitchen);
        }

        [TestMethod]
        public void ChefsOfKitchensOfBothRestaurantsAreEqual()
        {
            var chef = restaurant.Kitchen.Chef;
            var clonedChef = clonedRestaurant.Kitchen.Chef; //"clonedChef"
            Assert.AreEqual(chef, clonedChef);
        }

        [TestMethod]
        public void AssistantsOfChefsOfKitchensOfBothRestaurantsAreEqual()
        {
            var assistant = restaurant.Kitchen.Chef.Assistant;
            var clonedAssistant = clonedRestaurant.Kitchen.Chef.Assistant; //"clonedAssistant"
            Assert.AreEqual(assistant, clonedAssistant);
        }

        [TestCleanup]
        public void Cleanup()
        {
            restaurant = null;
            clonedRestaurant = null;
        }
    }
}
