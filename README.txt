Hello World.

Hi, this is a small library to convert lists of the form A, B, C to a string A, B, and C. Its also handles singular/plural prefixes/suffixes. 


<pre>
    var items = "Red || Green || Blue || Orange || Yellow";
    var separator = new string[] { "||" };
    IStringListProvider provider = new FlatStringListProvider(items, separator);

    var options = new NaturalLanguageListOptions();
    options.PrefixPlural = "are";
    options.PrefixSingular = "is a";
    options.SuffixPlural = "stickers";
    options.SuffixSingular = "sticker";
    options.Separator = ",";
    options.LastSeparator = "and";

    var languageList = languageHelper.NaturalLanguageList(options, provider);
    var sentence = "There are " + languageList + " for you on the table"
    
    
    Console.Writeline(sentence);
    
    Output:
    There are red, green, blue, orange, and yellow stickers for you on the table.

<pre>

See the console demo for more example usage

Tests included.
