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
    /// Логика взаимодействия для AddPairWindow.xaml
    /// </summary>
    public partial class AddPairWindow : Window
    {
        public AddPairWindow()
        {
            InitializeComponent();
            foreach (var i in App.IniController.GetSections()) {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                SectionNames.Items.Add(item);
            }
        }

        private void AddPair(object sender, RoutedEventArgs e)
        {
            App.IniController.AddPair(SectionNames.Text, key.Text, value.Text);
            this.Close();
        }
    }
}
