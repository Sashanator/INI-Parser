using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LabWork_1_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void AddPair(object sender, RoutedEventArgs e)
        {
            AddPairWindow addPairWindow = new AddPairWindow();
            addPairWindow.ShowDialog();
            this.Close();
        }

        private void AddSection(object sender, RoutedEventArgs e)
        {
            AddSectionWindow addSectionWindow = new AddSectionWindow();
            addSectionWindow.ShowDialog();
            this.Close();
        }
    }
}
