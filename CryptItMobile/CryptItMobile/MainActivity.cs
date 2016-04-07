using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CryptItMobile.Adapters;
using vkAPI;
using Model;

namespace CryptItMobile
{
    [Activity(Label = "CryptItMobile")]
    public class MainActivity : Activity
    {
        private ListView _friendsListView;
        private FriendsAdapter _friendsAdapter;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            
            _friendsListView = FindViewById<ListView>(Resource.Id.friendsListView);
            _friendsAdapter = new FriendsAdapter(this);
            _friendsListView.Adapter = _friendsAdapter;

            _friendsListView.ItemClick += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DialogActivity));
                intent.PutExtra("FriendId", _friendsAdapter._friends[e.Position].Id);//todo переделать когда перенесу друзей в активити
                StartActivity(intent);
            };
        }

        
    }
}

