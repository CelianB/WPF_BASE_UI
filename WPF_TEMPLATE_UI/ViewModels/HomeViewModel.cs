using System.Windows;
using System.Windows.Input;

namespace WPF_TEMPLATE_UI.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        #region Membres privées
        /// <summary>
        /// Fenetre controlées par le view model
        /// </summary>
        private Window window;

        /// <summary>
        /// Borer extérieur de la fenêtre (permet de faire les angles arrondi, les ombres derrière la fenetre etc...)
        /// </summary>
        private int outerMargin = 10;

        /// <summary>
        /// Tailes des coins de la fenêtre
        /// </summary>
        private int windowsRaduis = 10;
        #endregion
        #region Membres public

        public double WindowMinimumWidth { get; set; } = 1080;

        public double WindowMinimumHeight { get; set; } = 680;

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Page1;
        /// <summary>
        /// Padding interne
        /// </summary>
        public Thickness InnerContentPaddingThickness { get { return new Thickness(ResizeBorder); } }


        /// <summary>
        /// Taille de la border pour resizer (autour de la fenetre)   
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        /// <summary>
        /// Taille de la bordure autour de la fenetre
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OutMargin); } }

        public int SelectedMenuItem { get; set; } = 0;
        public Thickness MarginMenuUnderlineThickness { get { return new Thickness(10 + (SelectedMenuItem * 200), 0, 0, 0); } }

        /// <summary>
        /// Taille de la marge externe
        /// </summary>
        public int OutMargin {
            get {
                return window.WindowState == WindowState.Maximized ? 0 : outerMargin;
            }
            set {
                outerMargin = value;
            }
        }
        public Thickness OutMarginThickness { get { return new Thickness(OutMargin); } }

        /// <summary>
        /// Taille de angles dans les coins
        /// </summary>
        public int WindowRadius {
            get {
                return window.WindowState == WindowState.Maximized ? 0 : windowsRaduis;
            }
            set {
                windowsRaduis = value;
            }
        }
        public CornerRadius WindowRaduisCorner { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// Hauteur de la barre de titre
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        /// <summary>
        /// Recupère les informations de l'utilsiateur actuel (lecture de l'ad)
        /// </summary>
        #endregion
        #region Commands
        /// <summary>
        /// Commande pour minimiser la fenêtre
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Commande pour maximiser la fenêtre
        /// </summary>
        public ICommand MaximizeCommand { get; set; }
        
        /// <summary>
        /// Commande pour fermer la fenetre
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Commande pour afficher pour aller à l'acceuil 
        /// </summary>
        public ICommand MenuCommand { get; set; }

        /// <summary>
        /// Commande des boutons du menu principal
        /// </summary>
        public RelayCommand AppMenuCommand { get; set; }

        #endregion
        #region Constructeur
        /// <summary>
        /// Construcuteur par defaut
        /// </summary>
        public HomeViewModel(Window window)
        {
            // Active le menu d'action 
            this.window = window;
            this.window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));

                OnPropertyChanged(nameof(OutMargin));
                OnPropertyChanged(nameof(OutMarginThickness));

                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowRaduisCorner));
            };
            MinimizeCommand = new RelayCommand((object o) => this.window.WindowState = WindowState.Minimized);

            MaximizeCommand = new RelayCommand((object o) => this.window.WindowState ^= WindowState.Maximized);

            CloseCommand = new RelayCommand((object o) => this.window.Close());

            MenuCommand = new RelayCommand((object o) => SystemCommands.ShowSystemMenu(this.window, this.window.PointToScreen(Mouse.GetPosition(this.window))));

            AppMenuCommand  = new RelayCommand(ChangeMenu);

            var windowsResize = new WindowResizer(this.window);
        }


        #endregion
        #region Méthodes

        private void ChangeMenu(object obj)
        {
            this.SelectedMenuItem = int.Parse(obj.ToString());
            OnPropertyChanged(nameof(SelectedMenuItem));
            OnPropertyChanged(nameof(MarginMenuUnderlineThickness));

            switch (this.SelectedMenuItem)
            {
                case 0:
                    CurrentPage = ApplicationPage.Page1;
                    break;
                case 1:
                    CurrentPage = ApplicationPage.Page2;
                    break;
            }
        }

        #endregion
    }
}
