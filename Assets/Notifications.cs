using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
    DateTime splatTime;

    private void Start()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = "Splatcast",
            Name = "Splatcast",
            Importance = Importance.Default,
            Description = "Splatcast News"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotificationCenter.CancelAllScheduledNotifications();
        //TestNotif();
        for (int i = ((int)Mathf.Round(DateTime.Now.Hour/2) * 2)+2; i < 24; i+=2)
        {
            Lol(i,0);
        }
        for (int i = 0; i < 24; i+= 2)
        {
            Lol(i, 1);
        }
    }

    public void Lol(int hour, int day)
    {
        Debug.Log("Sending notification at "+ hour +"&"+ day);
        var notification = new AndroidNotification();
        notification.Title = "Splatcast!";
        notification.Text = "Stages just rotated!";
        DateTime today = DateTime.Today;
        notification.FireTime = new DateTime(today.Year, today.Month, today.Day + day, hour, 0, 0);
        AndroidNotificationCenter.SendNotification(notification, "Splatcast");
    }

    public void TestNotif()
    {
        var notification = new AndroidNotification();
        notification.Title = "Test Notification";
        notification.Text = "please just work";
        notification.FireTime = DateTime.Now.AddSeconds(30);
        AndroidNotificationCenter.SendNotification(notification, "Splatcast");
    }
}
