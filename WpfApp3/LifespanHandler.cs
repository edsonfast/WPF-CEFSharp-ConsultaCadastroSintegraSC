using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Wpf;


namespace WpfApp3 {
    public class LifespanHandler : ILifeSpanHandler {
        // event that receive url popup
        public event Action<string> popup_request;

        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser) {
            // get url popup
            popup_request?.Invoke(targetUrl);

            // stop open popup
            newBrowser = null/* TODO Change to default(_) if this is not a reference type */;
            return true;
        }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser) {
        }

        bool ILifeSpanHandler.DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser) {
            return false;
        }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser) {
        }
    }

}

