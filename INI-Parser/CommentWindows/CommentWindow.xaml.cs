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
    /// Логика взаимодействия для CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        public CommentWindow()
        {
            InitializeComponent();
        }

        private void SectionComments(object sender, RoutedEventArgs e)
        {
            AddDeleteSectionComments comments = new AddDeleteSectionComments(1);
            comments.ShowDialog();
            this.Close();
        }

        private void PairComments(object sender, RoutedEventArgs e)
        {
            AddDeleteSectionComments comments = new AddDeleteSectionComments(2);
            comments.ShowDialog();
            this.Close();
        }
    }
}
