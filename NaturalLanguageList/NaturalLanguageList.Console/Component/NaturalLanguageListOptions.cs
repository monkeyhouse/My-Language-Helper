using System;
using System.Linq;

namespace NaturalLanguageList.Console
{
    public class NaturalLanguageListOptions
    {

        public string PrefixSingular { get; set; }
        public string PrefixPlural { get; set; }
        public string SuffixSingular { get; set; }
        public string SuffixPlural { get; set; }


        public string Separator { get; set; }
        public string LastSeparator { get; set; }
        public bool ApplyOxfordSeparator { get; set; }

        public bool RemoveSpaceBeforeSuffix { get; set; }

        public string NoItemsText { get; set; }


        public NaturalLanguageListOptions GetSanatizedOptions( )
        {
            this.EvaluateOptions();
            return this.PopulateNullProperites().TrimOptions();
        }

        private void EvaluateOptions()
        {
           if (Separator == null || String.IsNullOrEmpty(Separator.Trim()))
               throw new ArgumentNullException("Separator", "Separator may not be null or empty");

           if (LastSeparator == null || String.IsNullOrEmpty(LastSeparator.Trim()))
               throw new ArgumentNullException("LastSeparator", "Last Separator may not be null or empty");

        }

        private NaturalLanguageListOptions PopulateNullProperites()
        {
            var props = typeof(NaturalLanguageListOptions).GetProperties()
                       .Where(x => x.PropertyType == typeof(string) && x.GetValue( this ) == null);
            foreach (var p in props)
            {
                p.SetValue(this, string.Empty, null);
            }

            return this;
        }


        private NaturalLanguageListOptions TrimOptions()
        {
            
            PrefixSingular = PrefixSingular.Trim();
            PrefixPlural = PrefixPlural.Trim();
            SuffixSingular = SuffixSingular.Trim();
            SuffixPlural = SuffixPlural.Trim();

            LastSeparator = LastSeparator.Trim();
            NoItemsText = NoItemsText.Trim();

            Separator = Separator.Trim();
            ApplyOxfordSeparator = ApplyOxfordSeparator;


            return this;
        }



    }
}