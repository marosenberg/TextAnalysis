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
            return Search(searchText, isCaseSensitive).Count();
        }
        public static WordSearcher FromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException($"File not found: {filePath}");
            }
            return new WordSearcher(File.ReadAllText(filePath));
        }

        public IEnumerable<WordLocation> Search(string searchText, bool isCaseSensitive = true)
        {
            StringComparison scomp = isCaseSensitive ? StringComparison.InvariantCulture :
               StringComparison.InvariantCultureIgnoreCase;
            int order = 1, ndx = Document.IndexOf(searchText, scomp);
            while (ndx >= 0)
            {
                yield return new WordLocation
                {
                    Word = searchText,
                    Location = ndx,
                    FoundOrder = order++
                };
                ndx = Document.IndexOf(searchText, ndx + searchText.Length, scomp);
            }
        }

        public Task<IEnumerable<WordLocation>> SearchAsync(string searchText, bool isCaseSensitive=true)
        {
            return Task<IEnumerable<WordLocation>>.Factory.StartNew(() => Search(searchText, isCaseSensitive));
        }
    }
}
