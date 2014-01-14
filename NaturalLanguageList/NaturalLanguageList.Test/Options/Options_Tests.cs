using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageList.Console;

namespace NaturalLanguageList.Test
{
    [TestClass]
    public class Natural_Language_List_Options_Tests
    {

       
        private NaturalLanguageListOptionsDummyProvider _optionsProvider;
        private NaturalLanguageListOptions _options;


        [TestInitialize]
        public void Setup()
        {

            _optionsProvider = new NaturalLanguageListOptionsDummyProvider();
            _options = _optionsProvider.CreateDummyOptions();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Separator_Should_Throw_An_Argument_Null_Exception()
        {
            _options.Separator = null;

            //Act
            _options.GetSanatizedOptions();

            //Assert
            Assert.Fail("Expected exception was not thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Last_Separator_Should_Throw_An_Argument_Null_Exception()
        {
            _options.LastSeparator = null;

            //Act
            _options.GetSanatizedOptions();

            //Assert
            Assert.Fail("Expected exception was not thrown.");
        }


        [TestMethod]      
        public void Null_Suffixes_And_Prefixes_Should_Be_Empty_Strings()
        {
            _options.PrefixSingular = null;
            _options.PrefixPlural = null;
            _options.SuffixSingular = null;
            _options.SuffixPlural = null;

            //Act
            var opts = _options.GetSanatizedOptions();

            //Assert
            Assert.AreEqual(String.Empty, opts.PrefixSingular);
            Assert.AreEqual(String.Empty, opts.PrefixPlural);
            Assert.AreEqual(String.Empty, opts.SuffixSingular);
            Assert.AreEqual(String.Empty, opts.SuffixPlural);
        }


    }
}
