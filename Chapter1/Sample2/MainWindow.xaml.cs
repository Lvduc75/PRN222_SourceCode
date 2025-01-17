using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;

namespace Sample2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        readonly HttpClient client = new HttpClient();
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();
        private void btnClear_Click(object seneder, RoutedEventArgs e)
        {
            txtContent.Text = string.Empty;
        }
        private async void btnViewHTML_Click(object sender, RoutedEventArgs e)
        {
            string uri = txtURL.Text;

            // Kiểm tra URL hợp lệ
            if (string.IsNullOrWhiteSpace(uri) || !Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                MessageBox.Show("Please enter a valid URL.");
                return;
            }

            try
            {
                string responseBody = await client.GetStringAsync(uri); // Gửi HTTP GET và nhận nội dung response
                txtContent.Text = responseBody.Trim();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Request Error: {ex.Message}");
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show($"Invalid URL format: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác (nếu có)
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }
    }
}