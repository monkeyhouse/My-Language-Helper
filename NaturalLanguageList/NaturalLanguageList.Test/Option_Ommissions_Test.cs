using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageList.Console;


namespace NaturalLanguageList.Test
{
    [TestClass]
    public class Natural_Language_List_Option_Ommissions_Test{

        private ListGenerator _listGenerator;
        private NaturalLanguageListOptionsDummyProvider _optionsProvider;
        private LanguageHelper _systemUnderTest;


        [TestInitialize]
        public void Setup()
        {
            _optionsProvider = new NaturalLanguageListOptionsDummyProvider();
            _systemUnderTest = new LanguageHelper();
        }

        [TestMethod]
        public void Can_Omit_Prefix_And_Suffix_For_Zero_Items()
        {
            //Arrange          
            _listGenerator = new ListGenerator(0, ",");
            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            options.PrefixSingular = null;
            options.SuffixSingular = null;
            var provider = new StringListProvider(_listGenerator.GetItemsList());

            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            var expected = options.NoItemsText;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Can_Omit_Prefix_For_Zero_Items()
        {
            //Arrange          
            _listGenerator = new ListGenerator(0, ",");
            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            options.PrefixSingular = null;
            var provider = new StringListProvider(_listGenerator.GetItemsList());

            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            var expected = options.NoItemsText + " " + options.SuffixSingular;
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Can_Omit_Prefix_And_Suffix_For_One_Item()
        {
            //Arrange          
            _listGenerator = new ListGenerator(1, ",");
            var items = _listGenerator.GetItems();
            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            options.PrefixSingular = null;
            options.SuffixSingular = null;
            var provider = new StringListProvider(_listGenerator.GetItemsList());

            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            var expected = items;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Can_Omit_Prefix_And_Suffix_For_Two_Items()
        {
            //Arrange          
            _listGenerator = new ListGenerator(2, ",");
            var list = _listGenerator.GetItemsList();
            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            options.PrefixPlural = null;
            options.SuffixPlural = null;
            var provider = new StringListProvider(_listGenerator.GetItemsList());

            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            var expected = list[0] + " " + options.LastSeparator + " " + list[1];
            Assert.AreEqual(expected, result);
        }
 
    }
}