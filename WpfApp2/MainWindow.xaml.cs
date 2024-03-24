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
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int matchesFound;
        int tenthOfSecondsElapsed ;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElapsed ++;
            timerTextBlock.Text = (tenthOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timerTextBlock.Text = timerTextBlock.Text + " - PLay Again ? ";
            }
                


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
                if(textBlock.Name != "timerTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }

            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0;

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
                matchesFound++;
                findingMatch = false;
                currentTextBlock.Visibility = Visibility.Hidden;
            }

            else
            {
                findingMatch = false;
                lastClickedTextBlock.Visibility = Visibility.Visible;
            }

        }

        private void timerTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
                SetUpGame();

        }
    }
}
