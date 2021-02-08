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

namespace MyStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page CheckOutPage;
        public WrapPanel IAmWrap;

        public MainWindow()
        {
            InitializeComponent();
            CheckOutPage = new Page
            {
                ShowsNavigationUI = false,

                Background = new SolidColorBrush(Color.FromArgb(150, 50, 0, 0)),
            };
            IAmWrap = new WrapPanel() { Orientation = Orientation.Vertical };

            IAmWrap = add2WrapAndReturnWrap(new TextBlock
            {
                Text = "Check Out\n-----------",
                Margin = new Thickness() { Bottom = 10, Left = 10, Top = 10, Right = 10 }
            });

            TextBlock textBlock = new TextBlock { Text = "Going to payment options" };
            IAmWrap.Children.Add(textBlock);
            CheckOutPage.Content = IAmWrap;
        }

        private WrapPanel NewWrapPanel(Orientation orientation)
        {
            return new WrapPanel();
        }

        private WrapPanel add2WrapAndReturnWrap(UIElement _UIobject, WrapPanel basePanel = null)
        {
            if (basePanel == null)
            {
                basePanel = new WrapPanel();
            }
            basePanel.Children.Add(_UIobject);

            return basePanel;
        }

        private void SampleSelected(object sender, RoutedEventArgs args)
        {
            if (sender is Button iAmButton)
            {
                var buttonTExt = (string)iAmButton?.Content;
                if (buttonTExt == "Check out")
                {
                    mainFrame.Navigate(CheckOutPage);
                    CheckOut();
                }
            }
            var rButton = sender as RadioButton;

            var buttonContent = (string)rButton?.Content;

            if (buttonContent != null)
            {
                if (buttonContent == "Show Cart")
                {
                    mainFrame.Navigate(new Page()
                    {
                        ShowsNavigationUI = false,
                        Background = new SolidColorBrush(Color.FromArgb(150, 50, 50, 50)),
                        Content = new StackPanel().Children.Add(new TextBlock() { Background = new SolidColorBrush(Colors.AliceBlue), Text = "Cart Content" })
                    });

                    rButton.Visibility = Visibility.Collapsed;
                }
                else if (buttonContent == "Back2Shop")
                {
                    rButton.Visibility = Visibility.Collapsed;

                    mainFrame.Navigate(new Page()
                    {
                        ShowsNavigationUI = false,
                        Background = new SolidColorBrush(Color.FromArgb(150, 0, 0, 50)),
                        Content = new StackPanel().Children.Add(new TextBlock() { Text = "Welcome to our Shop" })
                    });
                }
                else
                {
                    mainFrame.Navigate(new Page()
                    {
                        ShowsNavigationUI = false,
                        Background = new SolidColorBrush(Colors.Transparent),
                        Content = new StackPanel().Children.Add(new TextBlock() { Text = "Exiting" })
                    }); ;
                }
            }
        }

        private void ExitApplication(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }

        private void ShowMe(object sender, RoutedEventArgs e)
        {
            var rButton = sender as RadioButton;

            rButton.Visibility = Visibility.Visible;
        }

        private void HideButton(object sender, RoutedEventArgs e)
        {
            ShowShop.IsChecked = true;
            ShowShop.Visibility = Visibility.Collapsed;
        }

        private void CheckOut()
        {
            //          mainFrame.ContentRendered += mainFrame_ContentRendered;
        }

        private void CreateProductList()
        {
            ProductList productList = new ProductList();
            string name = "Intel i7";
            string description = "10th Gen 6 core CPU";
            Product p1 = new Product(name, description);
            name = "Intel i5";
            description = "10th Gen 4 core CPU";
            Product p2 = new Product(name, description);
            name = "Intel i3";
            description = "10th Gen 6 core CPU";
            Product p3 = new Product(name, description);
            name = "Intel i9";
            description = "10th Gen 10 core CPU";
            Product p4 = new Product(name, description);
            productList.Products.Add(p1);
            productList.Products.Add(p2);
            productList.Products.Add(p3);
            productList.Products.Add(p4);
        }
    }
}