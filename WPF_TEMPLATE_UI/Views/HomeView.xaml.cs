using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System;
using WPF_TEMPLATE_UI.ViewModels;

namespace WPF_TEMPLATE_UI.Views
{
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel(this);
        }
    }
}
