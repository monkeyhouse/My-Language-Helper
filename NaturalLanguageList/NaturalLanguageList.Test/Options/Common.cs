using System.Collections.Generic;
using System.Linq;

namespace NaturalLanguageList.Test
{
    public class Common
    {
        public bool AreEquivalent( List<string> x, List<string> y )
        {
            if ( x.Count() != y.Count() )
                return false;

            var xNotY = x.Except( y ).ToList();
            var yNotX = y.Except( x ).ToList();

            if ( xNotY.Count() != 0 | yNotX.Count() != 0 )
                return false;

            return true;
        }

    }
}