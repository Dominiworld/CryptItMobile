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
using Java.Net;
using vkAPI;

namespace CryptItMobile
{
    [Activity(Label = "StartActivity",  MainLauncher = true, Icon = "@drawable/icon")]
    public class StartActivity : Activity
    {
        WebView webView;
        private static readonly string AuthorizeUrl = AuthorizeService.Instance.GetAuthorizeUrl(5296011);
        private static Context _ctx;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Start);
            _ctx = this;
            webView = FindViewById<WebView>(Resource.Id.webView);
            webView.SetWebViewClient(new MyWebViewClient());
            webView.LoadUrl(AuthorizeUrl);
        }

        public class MyWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                var parseRef = new URL(url).Ref;
                if (parseRef!=null)
                {
                    var parseFields = parseRef.Split('&');

                    AuthorizeService.Instance.AccessToken = parseFields[0].Split('=')[1];
                    AuthorizeService.Instance.CurrentUserId = int.Parse(parseFields[2].Split('=')[1]);
                    AuthorizeService.Instance.GetCurrentUser();

                    var intent = new Intent(_ctx, typeof(MainActivity));//todo ��������, ��� ������� ��-�����������
                    _ctx.StartActivity(intent);
                }
                
                return false;
            }
        }
    }
}