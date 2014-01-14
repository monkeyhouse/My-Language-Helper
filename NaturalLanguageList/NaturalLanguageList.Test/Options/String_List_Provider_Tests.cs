using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaturalLanguageList.Console;

namespace NaturalLanguageList.Test
{
    [TestClass]
    public class String_List_Provider_Tests
    {
        /* Test variants on flat lists to make sure they return a sensible list<string>
         * ie "A,,B" should return "List<string>{"A","B"}
         */
        private Common _common;

        [TestInitialize]
        public void SetUp( )
        {
            _common = new Common();
        }
        [TestMethod]
        public void String_List_Provider_Returns_List( )
        {
            //Arrange
            var items = new List<string>() {"A", "B", "C", "D"};
            var provider = new StringListProvider(items);


            //Act
            var result = provider.GetItems();

            //Assert
            Assert.IsTrue(_common.AreEquivalent(items, result), "Lists are not equivalent");
        }

  

    }
}