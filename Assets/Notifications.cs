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
        for (int i = 0; i < 24; i+=2)
        {
            if (IsEven(DateTime.Now.Hour))
            {
                Lol(i+2, 0);
            }
            else
            {
                Lol(i + 1, 0);
            }
        }
        for (int i = 0; i < 24; i+= 2)
        {
            Lol(i, 1);
        }

        if (Debug.isDebugBuild)
        {
            TestNotif();
        }
    }

    public void Lol(int hour, int day)
    {
        Debug.Log("Sending notification at "+ hour +"&"+ day);
        var notification = new AndroidNotification();
        notification.Title = "Splatcast!";
        notification.Text = "Stages just rotated!";
        DateTime timing = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + day, DateTime.Now.Hour, 0, 0);
        //notification.FireTime = new DateTime(today.Year, today.Month, today.Day + day, hour, 0, 0);
        notification.FireTime = timing.AddHours(hour);
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
