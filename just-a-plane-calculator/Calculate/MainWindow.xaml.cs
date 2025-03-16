using just_a_plane_calculator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace just_a_plane_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string display = "0";
        private string history = "";
        private bool ClearScreen = true;
        private bool decimalInserted = false;

        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void InputNumber(object sender, RoutedEventArgs e)
        {
            string num = (sender as Button).Name.ToString().Remove(0, 1);

            if (display[0] == '0' && num == "0") { return; }
            if (ClearScreen) { display = ""; }

            display += num;
            ClearScreen = false;
            Update();
        }

        private void InputDecimal(object sender, RoutedEventArgs e)
        {
            if (ClearScreen) { display = "0"; }
            if (decimalInserted) { return; }
            display += (sender as Button).Content;
            decimalInserted = true;
            ClearScreen = false;
            Update();
        }

        private void InputArithmatic(object sender, RoutedEventArgs e)
        {
            if (display == "") { return; }
            ClearScreen = true;
            decimalInserted = false;
            history = display + $" {(sender as Button).Content} ";
            Update();
        }

        private void EvaluateArithmatic(object sender, RoutedEventArgs e)
        {
            if (history == "") { return; }
            // allows for the repeated input of an operation
            // basically if you press '=' after putting in something like 3 + 3
            // it will add 3 to the value of the operation (so history will say 6 + 3)

            string inputArithmatic;

            if (history.Contains("="))
            {
                string[] temp = history.Split(' '); // 3 + 20 =  ->  '3', '+', '20', '='
                temp[0] = display;
                inputArithmatic = String.Join(" ", temp);
                history = inputArithmatic;
            }
            else
            {
                inputArithmatic = history + display;
                history = inputArithmatic + " = ";

            }

            display = Calculate.CalculateString(inputArithmatic);
            HistoryAdd(history, display);
            ClearScreen = true;
            decimalInserted = false;
            Update();
        }

        //Invert the current number.
        private void FlipNum(object sender, RoutedEventArgs e)
        {
            if (display == "0") { return; }
            float tempNum = -1 * float.Parse(display);
            display = tempNum.ToString();
            Update();
        }

        //Clear the calculation.
        private void InputClear(object sender, RoutedEventArgs e)
        {
            display = "0";
            history = "";
            ClearScreen = true;
            Update();
        }

        //The calculator's "backspace" function.
        private void TrimNumberInput(object sender, RoutedEventArgs e)
        {
            if (display == "0") { return; }
            if (display.Length == 1 || display.Length == 2 && display.Contains("-"))
            {
                display = "0";
                ClearScreen = true;
            }
            else
            {
                display = display.Remove(display.Length - 1, 1);
            }
            Update();
        }

        //Square the current number.
        private void SqaureNum(object sender, RoutedEventArgs e)
        {
            if (display == "0") { return; }
            display = Calculate.Square(display);
            Update();
        }

        //Update the current display and history list.
        private void Update()
        {
            InputScreen.Text = display;
            InputHistory.Text = history;
            
        }

        //Adds current calculation to history list panel.
        private void HistoryAdd(string history, string currAns)
        {
            ListBoxItem newItem = new ListBoxItem();
            newItem.Content = history + currAns;
            HistoryList.Items.Add(newItem);

        }

        //Copy selected history item to clipboard
        private void HistorySelect_LeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            var historySelect = HistoryList.SelectedItem as ListBoxItem;
            
            if (historySelect != null)
            {
                string historyString = historySelect.Content.ToString();
                Clipboard.SetText(historyString);

                MessageBox.Show($"Calculation '{historyString}' copied to clipboard!");
            }
        }

    }
}