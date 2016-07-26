﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CacheManager.Core;

namespace CacheDemo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICacheManager<AwesomeClass> _awesomeCache;
        

        public MainWindow()
        {
            InitializeComponent();

            _awesomeCache = CacheFactory.Build<AwesomeClass>("myCache", settings =>
            {
                settings
                    .WithSystemRuntimeCacheHandle("inProcessCache")
                    .And
                    .WithRedisConfiguration("redis", config =>
                    {
                        config.WithAllowAdmin()
                            .WithDatabase(0)
                            .WithEndpoint("localhost", 6379);
                    })
                    .WithMaxRetries(1000)
                    .WithRetryTimeout(100)
                    .WithRedisBackplane("redis")
                    .WithRedisCacheHandle("redis", true);
            });

            AwesomeClasses = new ObservableCollection<AwesomeClass>();
        }

        public ObservableCollection<AwesomeClass> AwesomeClasses { get; set; }
    }
}
