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
using CefSharp;
using CefSharp.Wpf;

namespace WpfApp3 {
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // Block Pop-Up
            LifespanHandler life = new LifespanHandler();

            Browser.LifeSpanHandler = life;
            //life.popup_request += life_popup_request;
        }

        private void Browser_TitleChanged(object sender, DependencyPropertyChangedEventArgs e) {
            var chwb = sender as CefSharp.Wpf.ChromiumWebBrowser;

            lblTitulo.Content = chwb.Title;
        }

        private async void btnMostrar_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(await Browser.GetSourceAsync());
        }

        private async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            var strSource = await e.Browser.MainFrame.GetSourceAsync();

            // 'result_err.aspx?dat=031042' quando sem IE
            if (strSource.Contains("result_sitcad.aspx?dat=") && !strSource.Contains("Modelo aprovado pela Portaria SEF nº 375, de 26/08/2003.")) {
                int _idx = strSource.IndexOf("result_sitcad.aspx?dat=");
                string _dat = strSource.Substring(_idx + 23, 6);
                string _urlResult = "https://sat.sef.sc.gov.br/tax.NET/tax.net.cadastro/result_sitcad.aspx?dat=" + _dat;
                Browser.LoadUrl(_urlResult);

            }

        }
    }
}
