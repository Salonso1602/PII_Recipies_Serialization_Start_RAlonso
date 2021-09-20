using NUnit.Framework;
using Recipies;
using System.Globalization;

namespace LibraryTests
{
    [TestFixture]
    public class EquipmentTests
    {
        [SetUp]
        public void Setup()
        {
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        [Test]
        public void SerializeEquipmentTest()
        {
            string description = "Test Equipment";
            double hourlyCost = 9.99;
            string expected = $@"{{""Description"":""{description}"",""HourlyCost"":{hourlyCost}}}";

            IJsonConvertible equipment = new Equipment(description, hourlyCost);
            string actual = equipment.ConvertToJson();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeserializeEquipmentTest()
        {
            string description = "Test Equipment";
            double hourlyCost = 9.99;
            string json = $@"{{""Description"":""{description}"",""HourlyCost"":{hourlyCost}}}";

            Equipment equipment = new Equipment(json);

            Assert.AreEqual(description, equipment.Description);
            Assert.AreEqual(hourlyCost, equipment.HourlyCost);
        }
    }
}