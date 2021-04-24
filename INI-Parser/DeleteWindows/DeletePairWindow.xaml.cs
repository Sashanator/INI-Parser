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
    /// Логика взаимодействия для DeletePairWindow.xaml
    /// </summary>
    public partial class DeletePairWindow : Window
    {
        public DeletePairWindow()
        {
            InitializeComponent();
            foreach (var i in App.IniController.GetSections()) {
                SectionNames.Items.Add(i);
            }
        }

        private void DeleteSection(object sender, RoutedEventArgs e)
        {
            App.IniController.DeletePair(SectionNames.Text, PairNames.Text);
            this.Close();
        }

        private void SelectSectionToDelete(object sender, SelectionChangedEventArgs e)
        {
            PairNames.Items.Clear();
            foreach (var i in App.IniController.GetPairs(SectionNames.SelectedValue.ToString())) {
                PairNames.Items.Add(i);
            }
        }
    }
}
