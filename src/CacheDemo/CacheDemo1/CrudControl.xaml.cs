using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AwesomeLibrary;
using CacheDemo1.ViewModel;

namespace CacheDemo1
{
    /// <summary>
    /// Interaction logic for CrudControl.xaml
    /// </summary>
    public partial class CrudControl : UserControl
    {
        private AwesomeClassViewModel _viewModel;

        public CrudControl()
        {
            InitializeComponent();
            _viewModel = new AwesomeClassViewModel {Key = "AwesomeKey"};
            DataContext = _viewModel;
        }

        private void Reset()
        {
            _viewModel.Level = default(int);
            _viewModel.Something = default(string);
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var awesome = _viewModel.ToAwesomeClass();
            var success = MainWindow.AwesomeCache.Add(_viewModel.Key, awesome);

            if (!success)
            {
                MessageBox.Show(string.Format("Item with key '{0}' already exists", _viewModel.Key));
            }
        }

        private void getButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            
            var awesome = MainWindow.AwesomeCache.Get(_viewModel.Key);

            if(awesome == null)
                return;

            _viewModel.Level = awesome.AwesomenessLevel;
            _viewModel.Something = awesome.SomethingAwesome;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var awesome = _viewModel.ToAwesomeClass();
            var result = MainWindow.AwesomeCache.Update(_viewModel.Key, _ => awesome);

            if (result == null)
            {
                MessageBox.Show(string.Format("Item with key '{0}' does not exist", _viewModel.Key));
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AwesomeCache.Remove(_viewModel.Key);
            Reset();
        }
    }
}
