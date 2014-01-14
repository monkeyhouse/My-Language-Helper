using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageList.Console;

namespace NaturalLanguageList.Test
{
    [TestClass]
    public class Flat_String_List_Provider_Tests
    {
        /* Test variants on flat lists to make sure they return a sensible list<string>
         * ie "A,,B" should return "List<string>{"A","B"}
         */

        private Common _common;

        [TestInitialize]
        public void SetUp()
        {
            _common = new Common();

        }

        [TestMethod]
        public void Flat_Provider_Should_Parse_Comma_Separated_String( )
        {
            //Arrange
            var items = "A,B,C,D";
            var separator = new string[]{","};
            var provider = new FlatStringListProvider(items, separator);

            var expected = new List<string>() {"A", "B", "C", "D"};     

            //Act
            var result = provider.GetItems();

            //Assert
            Assert.IsTrue(_common.AreEquivalent(expected, result), "Lists are not equal");
                     
        }


        [TestMethod]
        public void Flat_Provider_Should_Parse_Comma_Separated_StringList_With_Empty_Elements()
        {
            //Arrange
            var items = ",A, ,B,C,D,,,";
            var separator = new string[] { "," };
            var provider = new FlatStringListProvider(items, separator);

            var expected = new List<string>() { "A", "B", "C", "D" };

            //Act
            var result = provider.GetItems();

            //Assert
            Assert.IsTrue(_common.AreEquivalent(expected, result), "Lists are not equal");
        }

    }


}