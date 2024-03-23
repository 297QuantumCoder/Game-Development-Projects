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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🦌", "🦌",
                "☠️","☠️",
                "🐖","🐖",
                "🦒","🦒",
                "🐒","🐒",
                "🐔","🐔",
                "🐿️","🐿️",
                "🐍","🐍"
            };

            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index]; 
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }

        TextBlock lastClickedTextBlock;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentTextBlock = sender as TextBlock;

            if(findingMatch ==  false)
            {
                lastClickedTextBlock = currentTextBlock;
                findingMatch = true;
                currentTextBlock.Visibility = Visibility.Hidden;
            }

            else if(lastClickedTextBlock.Text == currentTextBlock.Text)
            {
                findingMatch = false;
                currentTextBlock.Visibility = Visibility.Hidden;
            }

            else
            {
                findingMatch = false;
                lastClickedTextBlock.Visibility = Visibility.Visible;
            }

        }

      
    }
}
