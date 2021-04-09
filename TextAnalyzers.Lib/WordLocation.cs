using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzers.Lib
{
    public class WordLocation
    {
        public string Word { get; internal set; }
        public int Location { get; internal set; }
        internal int FoundOrder { get; set; }

        public override string ToString()
        {
            return $"#{FoundOrder} @ Position {Location}";
        }
    }
}
