using System;
using System.Collections.Generic;
using System.Linq;

namespace NaturalLanguageList.Console
{

    public interface IStringListProvider
    {
        List<string> GetItems();
    }

    public class StringListProvider : IStringListProvider
    {
        protected IEnumerable<string> _items;
       
        public StringListProvider(IEnumerable<string> items)
        {
            _items = items;
        }

        public List<string> GetItems()
        {
            return _items.ToList();
        }

    }

    public class FlatStringListProvider : IStringListProvider
    {
        protected string _items;
        protected string[] _separators;
        public FlatStringListProvider(string items, string[] separators)
        {
            _items = items;
            _separators = separators;

        }
        public List<string> GetItems()
        {
            string[] items = _items.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            var itemsTrim = items.Where(t => t.Trim().Length > 0)
                                  .Select(t => t.Trim()).ToList();

            return itemsTrim;

        }


    }
}