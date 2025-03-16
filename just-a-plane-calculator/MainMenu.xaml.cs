using just_a_plane_calculator.Notes;
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

namespace just_a_plane_calculator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        //Opens the calculator applet.
        private void LaunchCalculator(object sender, RoutedEventArgs e)
        {
            MainWindow calculatorWindow = new MainWindow();
            calculatorWindow.Show();
        }

        //Opens the notes applet.
        private void LaunchNote(object sender, RoutedEventArgs e)
        {
            NotesApplet notesWindow = new NotesApplet();
            notesWindow.Show();
        }
    }
}
