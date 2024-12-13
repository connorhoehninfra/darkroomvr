package com.connorhoehn.darkroomvr2;

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ServiceInfo;
import android.graphics.Color;
import android.os.IBinder;
import android.util.Log;
import com.unity3d.player.UnityPlayerForGameActivity;

public class DisplayCaptureNotificationService extends Service {

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        Log.i("DisplayCapture", "Service onStartCommand() is called");

        Intent activityIntent = new Intent(this, UnityPlayerForGameActivity.class);
        activityIntent.setAction("stop");
        PendingIntent contentIntent = PendingIntent.getActivity(this, 0, activityIntent, PendingIntent.FLAG_IMMUTABLE);

        String channelId = "001";
        String channelName = "myChannel";
        NotificationChannel channel = new NotificationChannel(channelId, channelName, NotificationManager.IMPORTANCE_NONE);
        channel.setLightColor(Color.BLUE);
        channel.setLockscreenVisibility(Notification.VISIBILITY_PRIVATE);

        NotificationManager manager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);

        if (manager != null) {
            manager.createNotificationChannel(channel);
            Notification notification = new Notification.Builder(getApplicationContext(), channelId)
                    .setOngoing(true)
                    .setCategory(Notification.CATEGORY_SERVICE)
                    .setContentTitle("Stop")
                    .setContentIntent(contentIntent)
                    .build();
            startForeground(5, notification, ServiceInfo.FOREGROUND_SERVICE_TYPE_MEDIA_PROJECTION);
        }

        return START_REDELIVER_INTENT;
    }
}