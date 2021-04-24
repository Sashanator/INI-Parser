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
    /// Логика взаимодействия для AddDeleteSectionComments.xaml
    /// </summary>
    public partial class AddDeleteSectionComments : Window
    {
        private int _flag;
        public AddDeleteSectionComments(int flag)
        {
            InitializeComponent();
            _flag = flag;
        }

        private void AddComment(object sender, RoutedEventArgs e)
        {
            AddCommentWindow window = new AddCommentWindow(_flag);
            window.ShowDialog();
            this.Close();
        }

        private void DeleteComment(object sender, RoutedEventArgs e)
        {
            DeleteCommentWindow window = new DeleteCommentWindow(_flag);
            window.ShowDialog();
            this.Close();
        }
    }
}
