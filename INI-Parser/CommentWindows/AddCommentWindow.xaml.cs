using System.Windows;
using System.Windows.Controls;

namespace LabWork_1_WPF.CommentWindows
{
    /// <summary>
    /// Логика взаимодействия для AddCommentWindow.xaml
    /// </summary>
    public partial class AddCommentWindow : Window
    {
        private int _flag;
        public AddCommentWindow(int flag)
        {
            InitializeComponent();
            foreach (var i in App.IniController.GetSections()) {
                SectionNames.Items.Add(i);
            }
            _flag = flag;
            if (_flag == 1) {
                KeyLabel.Visibility = Visibility.Collapsed;
                PairNames.Visibility = Visibility.Collapsed;
            }
        }

        private void SelectSectionToDelete(object sender, SelectionChangedEventArgs e)
        {
            PairNames.Items.Clear();
            foreach (var i in App.IniController.GetPairs(SectionNames.SelectedValue.ToString())) {
                PairNames.Items.Add(i);
            }
        }

        private void AddComment(object sender, RoutedEventArgs e)
        {
            if (_flag == 1) {
                App.IniController.AddSectionComment(SectionNames.Text, comment.Text);
            } else {
                App.IniController.AddPairComment(SectionNames.Text, PairNames.Text, comment.Text);
            }
            this.Close();
        }
    }
}
