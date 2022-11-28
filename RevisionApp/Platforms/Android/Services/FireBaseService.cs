﻿using Android.App;
using AndroidX.Core.App;
using Firebase.Messaging;

namespace RevisionApp.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] {"com.google.firebase.MESSAGING_EVENT"})]
    public class FirebaseService : FirebaseMessagingService
    {
        public FirebaseService()
        { 
        }

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            if (Preferences.ContainsKey("DeviceToken"))
            {
                Preferences.Remove("DeviceToken");
            }
            Preferences.Set("DeviceToken", token);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var notification = message.GetNotification();
            SendNotification(notification.Body, notification.Title, message.Data);
        }

        private void SendNotification(string messageBody, string title, IDictionary<string, string> data) 
        {
            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.ChannelId)
                .SetContentTitle(title)
                .SetContentText(messageBody)
                .SetSmallIcon(Resource.Mipmap.appicon)
                .SetChannelId(MainActivity.ChannelId);

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(MainActivity.Id, notificationBuilder.Build());
        }
    }
}
