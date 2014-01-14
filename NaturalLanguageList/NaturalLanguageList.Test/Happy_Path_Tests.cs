using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageList.Console;

namespace NaturalLanguageList.Test
{
    [TestClass]
    public class Natural_Language_List_Happy_Path_Tests
    {

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
        public void Zero_Items_Should_Return_ZeroItem_Text_With_Prefix_And_Suffix()
        {
            //Arrange          
            _listGenerator = new ListGenerator(0,",");
            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            var provider = new StringListProvider(_listGenerator.GetItemsList());

            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            var expected = options.PrefixSingular + " " + options.NoItemsText + " " + options.SuffixSingular;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void One_Item_Should_Return_A_Single_Item_With_Prefix_And_Suffix()
        {
            //Arrange
            _listGenerator = new ListGenerator(1, ",");
            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            var provider = new StringListProvider(_listGenerator.GetItemsList());
  
            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            var expected = options.PrefixSingular + " " + _listGenerator.GetItems() + " " + options.SuffixSingular;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Two_Items_Should_Return_Two_Items_With_A_Plural_Prefix_And_Suffix()
        {
            //Arrange
            _listGenerator = new ListGenerator(2, ",");

            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
           
            var items = _listGenerator.GetItemsList();
            var provider = new StringListProvider(items);

            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            StringAssert.StartsWith( result, options.PrefixPlural );
            StringAssert.EndsWith( result, options.SuffixPlural );

            var expected = options.PrefixPlural + " " + items[0] +
                           " " + options.LastSeparator + " " + items[1] +
                           " " + options.SuffixPlural;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Three_Items_Should_Return_A_Plural_Prefix_And_Suffix_And_Be_Seperated_By_A_Separator()
        {
            //Arrange
            _listGenerator = new ListGenerator(3, ",");

            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            options.ApplyOxfordSeparator = false;

            var items = _listGenerator.GetItemsList();
            var provider = new StringListProvider(items);


            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            StringAssert.StartsWith(result, options.PrefixPlural);
            StringAssert.EndsWith(result, options.SuffixPlural);

            var expected = options.PrefixPlural +
                           " " + items[0] + options.Separator +
                           " " + items[1] + " " + options.LastSeparator +
                           " " + items[2] +
                           " " + options.SuffixPlural;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Three_Items_Should_Be_Separated_By_An_Oxford_Separator()
        {
            //Arrange
            _listGenerator = new ListGenerator(3, ",");

            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            options.ApplyOxfordSeparator = true;

            var items = _listGenerator.GetItemsList();
            var provider = new StringListProvider(items);


            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, provider);

            //Assert
            var expected = options.PrefixPlural +
                           " " + items[0] + options.Separator +
                           " " + items[1] + options.Separator +
                           " " + options.LastSeparator + " " + items[2] +
                           " " + options.SuffixPlural;

            Assert.AreEqual(expected, result);
        }

      

     

    }
}