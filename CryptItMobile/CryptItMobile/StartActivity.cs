using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using vkAPI;

namespace CryptItMobile
{
    [Activity(Label = "StartActivity",  MainLauncher = true, Icon = "@drawable/icon")]
    public class StartActivity : Activity
    {
        WebView webView;
        private static readonly string AuthorizeUrl = AuthorizeService.Instance.GetAuthorizeUrl(5296011);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Start);

            webView = FindViewById<WebView>(Resource.Id.webview);
            webView.LoadUrl(AuthorizeUrl);
        }
    }
}