using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextAnalyzers.Lib;

namespace TextAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WordSearcher _wordSearcher;
        List<Tuple<WordLocation, TextRange>> _ranges;

        public MainWindow()
        {
            InitializeComponent();
            _wordSearcher = new WordSearcher("mobydick.txt");
            textArea.DragEnter += TextArea_DragEnter;
            textArea.Drop += TextArea_Drop;
            textArea.PreviewDragOver += TextArea_PreviewDragOver;
        }

        private void TextArea_PreviewDragOver(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TextArea_Drop(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TextArea_DragEnter(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void search_Click(object sender, RoutedEventArgs e)
        {
            string word = searchText.Text;
            bool isCaseSensitive = caseSensitive.IsChecked == true;
            IEnumerable<WordLocation> wordLocs = 
                await _wordSearcher.SearchAsync(word, isCaseSensitive);
            List<WordLocation> locations = wordLocs.ToList();
            ResultsCombo.ItemsSource = locations;
        }
    }
}
