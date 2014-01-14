using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageList.Console;

namespace NaturalLanguageList.Test
{
    [TestClass]
    public class Natural_Language_List_Sad_Path_Tests
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Options_Should_Return_Argument_Null_Exception()
        {
            //Arrange          
            _listGenerator = new ListGenerator(0,",");
            var provider = new StringListProvider(_listGenerator.GetItemsList());

            //Act
            var result = _systemUnderTest.NaturalLanguageList(null, provider);

            //Assert
            Assert.Fail("Expected exception was not thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Provider_Should_Return_Argument_Null_Exception()
        {
            //Arrange          
            _listGenerator = new ListGenerator(0, ",");
            var options = _optionsProvider.CreateDummyOptions().GetSanatizedOptions();
            var provider = new StringListProvider(_listGenerator.GetItemsList());

            //Act
            var result = _systemUnderTest.NaturalLanguageList(options, null);

            //Assert
            Assert.Fail("Expected exception was not thrown.");
        }

    }
}