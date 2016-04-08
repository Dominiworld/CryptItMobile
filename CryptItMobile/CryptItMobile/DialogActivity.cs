using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CryptItMobile.Adapters;
using vkAPI;
using Message = Model.Message;

namespace CryptItMobile
{
    [Activity(Label = "DialogActivity")]
    public class DialogActivity : Activity
    {
        private ListView _dialogListView;
        private DialogAdapter _dialogAdapter;
        private Button _sendButton;
        private EditText _messageText; 
        private MessageService _messageService=new MessageService();
        private LongPollServerService _longPollServerService=new LongPollServerService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Dialog);
            // Create your application here
            
            int friendId = Intent.GetIntExtra("FriendId", 0);

            _longPollServerService.ConnectToLongPollServer();


            _dialogListView = FindViewById<ListView>(Resource.Id.dialogListView);
            _dialogAdapter = new DialogAdapter(this, friendId);

            _longPollServerService.GotNewMessageEvent += _dialogAdapter.NewMessage;

            _dialogListView.Adapter = _dialogAdapter;

            _sendButton = FindViewById<Button>(Resource.Id.enterButton);
            _messageText = FindViewById<EditText>(Resource.Id.messageEditText);

            _sendButton.Click += (sender, e) =>
            {
                SendMessage(friendId);
                _messageText.Text = string.Empty;
            };
        }


        private async void SendMessage(int friendId)
        {
            await _messageService.SendMessage(friendId, _messageText.Text);
        }

    }
}