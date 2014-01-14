using System;
using System.Collections.Generic;
using System.Linq;
using NaturalLanguageList.Console;


namespace NaturalLanguageList.Test
{
    public class NaturalLanguageListOptionsDummyProvider
    {
        public NaturalLanguageListOptions CreateDummyOptions()
        {
            var options = new NaturalLanguageListOptions();
            options.PrefixSingular = "is a";
            options.PrefixPlural = "are";
            options.SuffixSingular = "car";
            options.SuffixPlural = "cars";


            options.Separator = ",";
            options.LastSeparator = "and";
            options.ApplyOxfordSeparator = true;
            options.NoItemsText = "Unknown";

            return options;
        }

    }

    public class ListGenerator
    {
        public string Items { get; set; }
        public string Separator { get; set; }
        public List<string> ItemsList { get; set; }

        public ListGenerator(int items, string separator)
        {

            var listItems = new String[items];

            foreach (var ix in Enumerable.Range(0, items))
            {
                listItems[ix] = "descriptor " + ix;
            }

            ItemsList = listItems.ToList();
            Items = String.Join(separator, listItems).Trim();
            Separator = separator;
        }

        public string GetItems()
        {
            return Items;
        }

        public string GetSeparator()
        {
            return Separator;
        }

        public List<string> GetItemsList()
        {
            return ItemsList;
        }

    }
}