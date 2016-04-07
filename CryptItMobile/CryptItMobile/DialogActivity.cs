using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CryptItMobile.Adapters;

namespace CryptItMobile
{
    [Activity(Label = "DialogActivity")]
    public class DialogActivity : Activity
    {
        private ListView _dialogListView;
        private DialogAdapter _dialogAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Dialog);
            // Create your application here
            int friendId = Intent.GetIntExtra("FriendId", 0);
            _dialogListView = FindViewById<ListView>(Resource.Id.dialogListView);
            _dialogAdapter = new DialogAdapter(this, friendId);
            _dialogListView.Adapter = _dialogAdapter;
        }
    }
}