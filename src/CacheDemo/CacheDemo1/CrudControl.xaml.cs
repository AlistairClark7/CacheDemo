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

namespace CacheDemo1
{
    /// <summary>
    /// Interaction logic for CrudControl.xaml
    /// </summary>
    public partial class CrudControl : UserControl
    {
        public CrudControl()
        {
            InitializeComponent();
            DataContext = this;
            Key = "AwesomeKey";
            Level = 1;
            Something = "Oh Wow";
        }

        public string Key { get; set; }
        public int Level { get; set; }
        public string Something { get; set; }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var awesome = new AwesomeClass
            {
                AwesomenessLevel = Level,
                SomethingAwesome = Something
            };

        }
    }
}
