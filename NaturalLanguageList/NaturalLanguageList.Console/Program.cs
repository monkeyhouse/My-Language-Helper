using NaturalLanguageList.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(100, 30);
            Console.WriteLine();
            var languageHelper = new LanguageHelper();


            var items = "Red || Green || Blue || Orange || Yellow";
            var separator = new string[] { "||" };
            IStringListProvider provider = new FlatStringListProvider(items, separator);

            var options = new NaturalLanguageListOptions();
            options.PrefixPlural = "are";
            options.PrefixSingular = "is";
            options.SuffixPlural = "stickers";
            options.SuffixSingular = "sticker";
            options.Separator = ",";
            options.LastSeparator = "and";

            var languageList = languageHelper.NaturalLanguageList(options, provider);
            var sentence = "There are " + languageList + " for you on the table";

            Console.WriteLine(items);
            Console.WriteLine(sentence);

            Console.ReadLine();

            var itemsArray = new String[]{"hammock", "futon", "pillow", "gym mat"};
            provider = new StringListProvider(itemsArray);

            options = new NaturalLanguageListOptions();
            options.PrefixPlural = "either a";
            options.PrefixSingular = "a";
            options.SuffixPlural = ". They are";
            options.SuffixSingular = ". It's"; 
            options.Separator = ",";
            options.LastSeparator = "or";
            options.ApplyOxfordSeparator = true;
            options.RemoveSpaceBeforeSuffix = true;

            languageList = languageHelper.NaturalLanguageList(options, provider);
            sentence = "What would you like to sleep on tonight? You can have have " + languageList + " in the garage";

            Console.WriteLine(String.Join(",",itemsArray));
            Console.WriteLine(sentence);

            Console.WriteLine();
            itemsArray = new String[] { "dusty comforter" };
            provider = new StringListProvider(itemsArray);
            languageList = languageHelper.NaturalLanguageList(options, provider);
            sentence = "What would you like to sleep on tonight? You can have have " + languageList + " in the garage";
            Console.WriteLine(String.Join(",", itemsArray));
            Console.WriteLine(sentence);


            Console.ReadLine();

            ////Act
            //var result = provider.GetItems();

            ////Assert
            //Assert.IsTrue(_common.AreEquivalent(expected, result), "Lists are not equal");

            ////Arrange
            //var items = ",A, ,B,C,D,,,";
            //var separator = new string[] { "," };
            //var provider = new FlatStringListProvider(items, separator);

            //var expected = new List<string>() { "A", "B", "C", "D" };

            ////Act
            //var result = provider.GetItems();

            ////Assert
            //Assert.IsTrue(_common.AreEquivalent(expected, result), "Lists are not equal");

        }
    }
}
