using LabWork_1_WPF.CommentWindows;
using LabWork_1_WPF.DeleteWindows;
using System;
using System.IO;
using System.Windows;

namespace LabWork_1_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ParseBt.IsEnabled = false;
            ShowBt.IsEnabled = false;
            AddBt.IsEnabled = false;
            DelBt.IsEnabled = false;
            CommentBt.IsEnabled = false;
            
            AcceptBt.IsEnabled = false;
            filePath.IsEnabled = false;
            
            exBt.IsEnabled = false;

            ValueType.IsEnabled = false;
            SectionNames.IsEnabled = false;
            PairNames.IsEnabled = false;
            btOk.IsEnabled = false;
        }

        private void btExiot(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrintFile(object sender, RoutedEventArgs e)
        {
            fileText.Text = App.IniController.GetFile();
        }

        private void ParseFile(object sender, RoutedEventArgs e)
        {
            App.IniController.Parse();
            foreach (var i in App.IniController.GetSections()) {
                SectionNames.Items.Add(i);
            }
            ShowBt.IsEnabled = true;
            AddBt.IsEnabled = true;
            DelBt.IsEnabled = true;
            CommentBt.IsEnabled = true;

            ValueType.IsEnabled = true;
            SectionNames.IsEnabled = true;
            PairNames.IsEnabled = true;
            btOk.IsEnabled = true;

            ParseBt.IsEnabled = false;
        }

        private void AcceptFilePath(object sender, RoutedEventArgs e)
        {
            if (filePath.Text.Length > 4 && filePath.Text.Contains("ini") 
                                        && File.Exists(filePath.Text)) {
                App.IniController = new IniController(filePath.Text);
                ParseBt.IsEnabled = true;
                MessageBox.Show("Путь к файлу установлен!",
                        "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            } else {
                MessageBox.Show("Неверный путь к файлу!",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            deleteWindow.ShowDialog();
        }

        private void Comments(object sender, RoutedEventArgs e)
        {
            CommentWindow window = new CommentWindow();
            window.ShowDialog();
        }

        private void SelectSectionToDelete(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            PairNames.Items.Clear();
            foreach (var i in App.IniController.GetPairs(SectionNames.SelectedValue.ToString())) {
                PairNames.Items.Add(i);
            }
        }

        private void ClickOk(object sender, RoutedEventArgs e)
        {
            if (IntItem.IsSelected) {
                try {
                    MessageBox.Show($"Получено значение целого типа: " +
                        $"{App.IniController.GetIntValue(SectionNames.Text, PairNames.Text)}",
                        "Ваше значение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (FormatException ex) {
                    MessageBox.Show($"Неверный тип параметра! Ошибка: {ex.Message}",
                        "Ваше значение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else if (FloatItem.IsSelected) {
                try {
                    MessageBox.Show($"Получено значение вещественного типа: " +
                        $"{App.IniController.GetDoubleValue(SectionNames.Text, PairNames.Text)}",
                        "Ваше значение", MessageBoxButton.OK, MessageBoxImage.Information);
                } catch (FormatException ex) {
                    MessageBox.Show($"Неверный тип параметра! Ошибка: {ex.Message}",
                        "Ваше значение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else {
                try {
                    MessageBox.Show($"Получено значение строкового типа: " +
                        $"{App.IniController.GetStringValue(SectionNames.Text, PairNames.Text)}",
                        "Ваше значение", MessageBoxButton.OK, MessageBoxImage.Information);
                } catch (FormatException ex) {
                    MessageBox.Show($"Неверный тип параметра! Ошибка: {ex.Message}",
                        "Ваше значение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            infoMessage.Visibility = Visibility.Collapsed;
            AcceptBt.IsEnabled = true;
            filePath.IsEnabled = true;
            exBt.IsEnabled = true;
            //filePath.IsEnabled = true;
            //exBt.IsEnabled = true;
            //MainGrid.IsEnabled = true;
            //ValueType.IsEnabled = true;
            //SectionNames.IsEnabled = true;
            //PairNames.IsEnabled = true;
            //btOk.IsEnabled = true;
        }
    }
}
