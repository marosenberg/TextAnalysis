using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzers.Lib
{
    public class WordSearcher
    {
        public WordSearcher(string _document)
        {
            if (string.IsNullOrEmpty(_document))
            {
                throw new ArgumentNullException(nameof(_document));
            }
            Document = _document;
        }
        public string Document { get; private set; }

        public int GetWordCount(string searchText, bool isCaseSensitive = true)
        {
            StringComparison scomp = isCaseSensitive ? StringComparison.InvariantCulture :
                StringComparison.InvariantCultureIgnoreCase;
            int count = 0;
            int ndx =Document.IndexOf(searchText, scomp);
            while (ndx >= 0)
            {
                count++;
                ndx = Document.IndexOf(searchText, ndx + searchText.Length, scomp);
            }
            return count;
        }
        public static WordSearcher FromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"File not found: {filePath}");
            }
            return new WordSearcher(File.ReadAllText(filePath));
        }
    }
}
