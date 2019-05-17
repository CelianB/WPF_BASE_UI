using System.Windows;
using System.Windows.Controls;

namespace WPF_TEMPLATE_UI.Views
{
    /// <summary>
    /// Logique d'interaction pour HeaderView.xaml
    /// </summary>
    public partial class HeaderView : UserControl
    {        public static readonly DependencyProperty titreProperty = DependencyProperty.Register
            (
                 "Title",
                 typeof(string),
                 typeof(HeaderView),
                 new UIPropertyMetadata(string.Empty)
            );

        public string Title {
            get { return (string)GetValue(titreProperty); }
            set { SetValue(titreProperty, value); }
        }


        public HeaderView()
        {
            InitializeComponent();
        }
    }
}
