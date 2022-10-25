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

namespace WpfApp3 {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private async void Browser_TitleChanged(object sender, DependencyPropertyChangedEventArgs e) {

            var chwb = sender as CefSharp.Wpf.ChromiumWebBrowser;

            lblTitulo.Content = chwb.Title;
            HtmlSource.Text = await chwb.BrowserCore.MainFrame.GetSourceAsync(); //chwb.GetBrowser().MainFrame.Url ;

            // Carrega o resultado da pesquisa na mesma janela (Sintegra 2022)
            if (HtmlSource.Text.Contains("result_sitcad.aspx?dat=") && !Browser.Address.Contains("https://sat.sef.sc.gov.br/tax.NET/tax.net.cadastro/result_sitcad.aspx")) {
                int _idx = HtmlSource.Text.IndexOf("result_sitcad.aspx?dat=");
                string _dat = HtmlSource.Text.Substring(_idx + 23, 6);
                string _urlResult = "https://sat.sef.sc.gov.br/tax.NET/tax.net.cadastro/result_sitcad.aspx?dat=" + _dat;
                Browser.LoadUrl(_urlResult);
            }
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(HtmlSource.Text);
        }
    }
}
