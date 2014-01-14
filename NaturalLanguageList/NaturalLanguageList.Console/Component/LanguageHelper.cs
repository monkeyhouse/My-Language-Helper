using System;
using System.Collections;
using System.Text;

namespace NaturalLanguageList.Console
{
    public class LanguageHelper
    {
        /// <summary>
        /// Returns a list according to English grammar rules. Converts strings such as  A,B,C into A, B, and C. Also handles singular/plural prefixes/suffixes.  Quite fancy.
        /// </summary>
        /// <remarks>
        /// strings or string[] are passsed through a IStringListProvider
        /// prefixes, suffixes, and other options are passed thorugh NaturalLanguageListOptions
        /// </remarks>
        public string NaturalLanguageList( NaturalLanguageListOptions options, IStringListProvider itemsProvider)
        {

            if (itemsProvider == null)
                throw new ArgumentNullException("itemsProvider", "An IItemsProvider is required");

            if (options == null)
                throw new ArgumentNullException("options", "LanguageList options are required");

            var items = itemsProvider.GetItems().ToArray();
            var opts = options.GetSanatizedOptions();

            var languageList = new StringBuilder();

            var suffixSpacer = opts.RemoveSpaceBeforeSuffix ? String.Empty : " ";

            if (items.Length == 0)
            {
                languageList.Append(opts.PrefixSingular + " " + opts.NoItemsText + suffixSpacer + opts.SuffixSingular);
                return languageList.ToString().Trim();
            }

            if (items.Length == 1)
            {
                languageList.Append(opts.PrefixSingular + " " + items[0] + suffixSpacer + opts.SuffixSingular);
                return languageList.ToString().Trim();
            }


            //if it reaches here there is more than one element in the items array (two or more)
            if (!String.IsNullOrWhiteSpace(opts.PrefixPlural))
                languageList.Append(opts.PrefixPlural + " ");

            //for each element in the array exept for the last one
            for (int index = 0; index < items.Length - 2; index++)
            {
                languageList.Append(items[index] + opts.Separator + " ");
            }

            //conditionally apply the oxford seperator ie. ", and" vs " and "
            var lastSeparator = opts.ApplyOxfordSeparator && items.Length > 2
                                     ? opts.Separator.Trim() + " " +  opts.LastSeparator + " "
                                     : " " + opts.LastSeparator + " ";


            languageList.Append(items[items.Length - 2] + lastSeparator +
                                        items[items.Length - 1] + suffixSpacer + opts.SuffixPlural);

            return languageList.ToString().Trim();
        }
    }
}
