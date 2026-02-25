using SmartBalance.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace SmartBalance.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddIncomePage.xaml
    /// </summary>
    public partial class AddIncomePage : Page
    {
        enum PaymentType
        {
            None,
            Cash,
            Card
        }

        private PaymentType selectedPaymentType = PaymentType.None;

        public AddIncomePage()
        {
            InitializeComponent();
            DataContext = new IncomeViewModel();
        }

        // Проверка на введенные данные
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs inputedInformation)
        {
            Regex regex = new Regex(@"^[0-9]*[,.]?[0-9]*$");
            inputedInformation.Handled = !regex.IsMatch(inputedInformation.Text);
        }

        private async void CancellationButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.NavigationService != null)
            {
                var fadeOut = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromSeconds(0.7)
                };
                this.BeginAnimation(Page.OpacityProperty, fadeOut);

                await Task.Delay(700);

                var fadeIn = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.4)
                };
                MainWindow.incomePage.BeginAnimation(OpacityProperty, fadeIn);

                this.NavigationService.Navigate(MainWindow.incomePage);
            }
        }

        // Анимация выбора типа кошелька
        private void ChooseWalletAnimation(UIElement element, double to)
        {
            var animation = new DoubleAnimation()
            {
                To = to,
                Duration = TimeSpan.FromSeconds(0.3),
                FillBehavior = FillBehavior.HoldEnd
            };
            element.BeginAnimation(OpacityProperty, animation);
        }

        private void CardControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selectedPaymentType == PaymentType.Card)
            {
                return;
            }

            ChooseWalletAnimation(CardControl, 1);
            ChooseWalletAnimation(CashControl, 0.3);

            selectedPaymentType = PaymentType.Card;
        }
        private void CashControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (selectedPaymentType == PaymentType.Cash)
            {
                return;
            }

            ChooseWalletAnimation(CashControl, 1);
            ChooseWalletAnimation(CardControl, 0.3);

            selectedPaymentType = PaymentType.Cash;
        }
    }
}
