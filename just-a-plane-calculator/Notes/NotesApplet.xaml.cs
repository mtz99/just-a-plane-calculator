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
using System.Windows.Shapes;

namespace just_a_plane_calculator.Notes
{
    /// <summary>
    /// Interaction logic for NotesApplet.xaml
    /// </summary>
    public partial class NotesApplet : Window
    {
        private bool placeholderActive = true;

        public NotesApplet()
        {
            InitializeComponent();
        }

        //Add new note to note list box.
        private void NotesAdd(object sender, RoutedEventArgs e)
        {
            string inputText = ListEntry.Text;
            ListBoxItem newItem = new ListBoxItem();
            newItem.Content = inputText;
            ListPane.Items.Add(newItem);
            ListEntry.Text = "";

        }


        //Copy selected note to clipboard
        private void NotesSelect_LeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            var listPaneSelect = ListPane.SelectedItem as ListBoxItem;

            if (listPaneSelect != null)
            {
                string listPaneString = listPaneSelect.Content.ToString();
                Clipboard.SetText(listPaneString);

                MessageBox.Show($"Message: '{listPaneString}' copied to clipboard!");
            }
        }

        //Remove a selected note upon right clicking.
        private void NotesRemove_RightMouseButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        { 
            if (ListPane.SelectedItem != null)
            {
                ListPane.Items.Remove(ListPane.SelectedItem);
            }
        }

        //Hide textbox placeholder message upon selecting it.
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (placeholderActive)
            {
                ListEntry.Text = "";
                ListEntry.Foreground = Brushes.Black;
                placeholderActive = false;
            }
        }

        //Show textbox placeholder message if there's nothing in it and is not selected.
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ListEntry.Text))
            {
                ListEntry.Text = "Enter text here...";
                ListEntry.Foreground = Brushes.Gray;
                placeholderActive = true;
            }
        }
    }
}
