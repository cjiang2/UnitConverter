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
            MainFrame.Navigate(typeof(AreaPage));
            Button1.IsChecked = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;   // Hamburger Menu
        }

        // Back Navigation Set-up
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                e.Handled = true;
                MainFrame.GoBack();
            }
            // Change selection of Hamburger Items
            if (MainFrame.CurrentSourcePageType.Equals(typeof(AreaPage)))
            {
                Button1.IsChecked = true;
            }
            else if (MainFrame.CurrentSourcePageType.Equals(typeof(DistPage)))
            {
                Button2.IsChecked = true;
            }
            else if (MainFrame.CurrentSourcePageType.Equals(typeof(TimePage)))
            {
                Button3.IsChecked = true;
            }
            else if (MainFrame.CurrentSourcePageType.Equals(typeof(AboutPage)))
            {
                AboutButton.IsChecked = true;
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    MainFrame.CanGoBack ?
                    AppViewBackButtonVisibility.Visible :
                    AppViewBackButtonVisibility.Collapsed;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(AreaPage));
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(DistPage));
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(TimePage));
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(AboutPage));
        }
    }
}
