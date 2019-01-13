using NUnit.Framework;
using WP.Drinks.Builders;

namespace Tests
{
    public class Singleton
    {
        [Test]
        public void CubaLibreBuilderIsSingleton()
        {
            CubaLibreBuilder cubaLibreBuilder1 = CubaLibreBuilder.Builder;
            CubaLibreBuilder cubaLibreBuilder2 = CubaLibreBuilder.Builder;

            Assert.AreSame(cubaLibreBuilder1, cubaLibreBuilder2);
        }

        [Test]
        public void GinTonicBuilderIsSingleton()
        {
            GinTonicBuilder ginTonicBuilder1 = GinTonicBuilder.Builder;
            GinTonicBuilder ginTonicBuilder2 = GinTonicBuilder.Builder;

            Assert.AreSame(ginTonicBuilder1, ginTonicBuilder2);
        }

        [Test]
        public void ScrewdriverBuilderIsSingleton()
        {
            ScrewdriverBuilder screwdriverBuilder1 = ScrewdriverBuilder.Builder;
            ScrewdriverBuilder screwdriverBuilder2 = ScrewdriverBuilder.Builder;

            Assert.AreSame(screwdriverBuilder1, screwdriverBuilder2);
        }
    }
}