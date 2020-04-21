using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;


public class NotificationManager : MonoBehaviour
{
    private string notifTitle;
    private string notifContent;
    private TimeSpan repeatInterval;
    private DateTime fireTime;
    private void Start()
    {
        notifTitle = "EI Trainer";
        notifContent = "Take a moment to complete the Reflection activity";
        var defaultNotificationChannel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Default notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(defaultNotificationChannel);

        


    }

    //sends notification after player pauses game
    private void OnApplicationPause(bool pause)
    {
        repeatInterval = new TimeSpan(3, 0, 0); //set time span to 3 hours
        fireTime = DateTime.Now.AddHours(3); //send first notif in 3 hours
        AndroidNotification notification = new AndroidNotification(notifTitle, notifContent, fireTime, repeatInterval);
        var identifier = AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
}
