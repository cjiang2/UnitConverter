using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        private void HamburgerListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;   // Hamburger Menu

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
        MainFrame.CanGoBack ?
        AppViewBackButtonVisibility.Visible :
        AppViewBackButtonVisibility.Collapsed;

        }

        // Back Navigation Set-up
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                e.Handled = true;
                MainFrame.GoBack();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
