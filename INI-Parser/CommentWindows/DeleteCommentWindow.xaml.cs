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

namespace LabWork_1_WPF.CommentWindows
{
    /// <summary>
    /// Логика взаимодействия для DeleteCommentWindow.xaml
    /// </summary>
    public partial class DeleteCommentWindow : Window
    {
        private int _flag;
        public DeleteCommentWindow(int flag)
        {
            InitializeComponent();
            _flag = flag;
            if (_flag == 1) {
                KeyLabel.Visibility = Visibility.Collapsed;
                PairNames.Visibility = Visibility.Collapsed;
                foreach (var i in App.IniController.GetOnlySectionComments()) {
                    SectionNames.Items.Add(i);
                }
            } else {
                foreach (var i in App.IniController.GetSectionWithComments()) {
                    SectionNames.Items.Add(i);
                }
            }
        }

        private void SelectSectionToDelete(object sender, SelectionChangedEventArgs e)
        {
            PairNames.Items.Clear();
            foreach (var i in App.IniController.GetPairComments(SectionNames.SelectedValue.ToString())) {
                PairNames.Items.Add(i);
            }
        }

        private void DeleteSection(object sender, RoutedEventArgs e)
        {
            if (_flag == 1) {
                App.IniController.DeleteSectionComment(SectionNames.Text);
            } else {
                App.IniController.DeletePairComment(SectionNames.Text, PairNames.Text);
            }
            this.Close();
        }
    }
}
