using System.Windows;

namespace LabWork_1_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddSectionWindow.xaml
    /// </summary>
    public partial class AddSectionWindow : Window
    {
        public AddSectionWindow()
        {
            InitializeComponent();
        }

        private void AddSection(object sender, RoutedEventArgs e)
        {
            App.IniController.AddSection(sectionName.Text);
            this.Close();
        }
    }
}
