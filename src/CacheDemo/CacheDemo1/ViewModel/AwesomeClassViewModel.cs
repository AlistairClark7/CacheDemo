using AwesomeLibrary;
using Prism.Mvvm;

namespace CacheDemo1.ViewModel
{
    public class AwesomeClassViewModel : BindableBase
    {
        private string _key;
        private int _level;
        private string _something;

        public string Key
        {
            get { return _key; }
            set { SetProperty(ref _key, value); }
        }

        public int Level
        {
            get { return _level; }
            set { SetProperty(ref _level, value); }
        }

        public string Something
        {
            get { return _something; }
            set { SetProperty(ref _something, value); }
        }

        public AwesomeClass ToAwesomeClass()
        {
            return new AwesomeClass
            {
                AwesomenessLevel = Level,
                SomethingAwesome = Something
            };
        }
    }
}