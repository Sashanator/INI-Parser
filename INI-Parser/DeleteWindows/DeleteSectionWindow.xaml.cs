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
    /// Логика взаимодействия для DeleteSectionWindow.xaml
    /// </summary>
    public partial class DeleteSectionWindow : Window
    {
        public DeleteSectionWindow()
        {
            InitializeComponent();
            foreach (var i in App.IniController.GetSections()) {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                SectionNames.Items.Add(item);
            }
        }

        private void DeleteSection(object sender, RoutedEventArgs e)
        {
            App.IniController.DeleteSection(SectionNames.Text);
            this.Close();
        }
    }
}
