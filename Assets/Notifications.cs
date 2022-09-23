#if UNITY_ANDROID


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
            Importance = Importance.High,
            Description = "Splatcast News"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        AndroidNotificationCenter.CancelAllScheduledNotifications();
        //TestNotif();
        for (int i = 0; i < 168; i+=2)
        {
            if (IsEven(DateTime.Now.ToUniversalTime().Hour))
            {
                Debug.Log(IsEven(DateTime.Now.ToUniversalTime().Hour));
                Lol(i + 2, 0);
            }
            else
            {
                Debug.Log(IsEven(DateTime.Now.ToUniversalTime().Hour));
                Lol(i + 1, 0);
            }
        }

        if (Debug.isDebugBuild)
        {
            //TestNotif();
        }
    }

    public void Lol(int hour, int day)
    {
        var notification = new AndroidNotification();
        DateTime timing = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
        notification.Title = "Splatcast!";
        notification.Text = "Stages just rotated!";
        notification.ShowTimestamp = true;
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";
        //notification.FireTime = new DateTime(today.Year, today.Month, today.Day + day, hour, 0, 0);
        notification.FireTime = timing.AddHours(hour);
        Debug.Log("Sending notification at "+ timing.AddHours(hour));
        AndroidNotificationCenter.SendNotification(notification, "Splatcast");
    }

    public void TestNotif()
    {
        for (int i = 0; i < 60; i+=1)
        {
            var notification = new AndroidNotification();
            notification.Title = "Debug Notif";
            notification.Text = "DebugNotif";
            DateTime today = DateTime.Today;
            notification.FireTime = DateTime.Now.AddMinutes(i);
            AndroidNotificationCenter.SendNotification(notification, "Splatcast");

        }
    }

    public bool IsEven(int num)
    {
        if (num % 2 == 0)
        {
            return true;
        }
        return false;

    }
}
#endif