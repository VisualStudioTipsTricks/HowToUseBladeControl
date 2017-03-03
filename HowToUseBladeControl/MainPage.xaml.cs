using HowToUseBladeControl.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HowToUseBladeControl
{
    public sealed partial class MainPage : Page
    {
        MainViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = this.Resources["viewmodel"] as MainViewModel;
            this.ViewModel.PriceConfirmed += (s, e) => { this.PriceBlade.IsOpen = false; };
        }

        private void DetailBlade_VisibilityChanged(object sender, Visibility e)
        {
            if (e == Visibility.Collapsed)
            {
                this.PriceBlade.IsOpen = false;
            }
        }
    }
}