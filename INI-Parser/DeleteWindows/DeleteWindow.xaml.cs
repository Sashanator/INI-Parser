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

namespace LabWork_1_WPF.DeleteWindows
{
    /// <summary>
    /// Логика взаимодействия для DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
        }

        private void DeletePair(object sender, RoutedEventArgs e)
        {
            DeletePairWindow deletePairWindow = new DeletePairWindow();
            deletePairWindow.ShowDialog();
            this.Close();
        }

        private void DeleteSection(object sender, RoutedEventArgs e)
        {
            DeleteSectionWindow deleteSectionWindow = new DeleteSectionWindow();
            deleteSectionWindow.ShowDialog();
            this.Close();
        }
    }
}
