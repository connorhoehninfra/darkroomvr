package com.connorhoehn.darkroomvr2;

import android.app.Service;
import android.content.Intent;
import android.graphics.PixelFormat;
import android.hardware.display.DisplayManager;
import android.hardware.display.VirtualDisplay;
import android.media.projection.MediaProjection;
import android.media.projection.MediaProjectionManager;
import android.os.IBinder;
import android.util.DisplayMetrics;
import android.view.Surface;
import android.view.SurfaceView;
import android.view.WindowManager;

public class ScreenCaptureService extends Service {
    private MediaProjectionManager projectionManager;
    private MediaProjection mediaProjection;
    private VirtualDisplay virtualDisplay;
    private SurfaceView surfaceView;
    private Surface surface;

    @Override
    public void onCreate() {
        super.onCreate();
        projectionManager = (MediaProjectionManager) getSystemService(MEDIA_PROJECTION_SERVICE);
        surfaceView = new SurfaceView(this);
        surface = surfaceView.getHolder().getSurface();
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        int resultCode = intent.getIntExtra("resultCode", -1);
        Intent data = intent.getParcelableExtra("data");

        if (resultCode != -1) { // Activity.RESULT_OK is -1
            android.util.Log.e("ScreenCaptureService", "Screen Cast Permission Denied");
            stopSelf();
            return START_NOT_STICKY;
        }

        mediaProjection = projectionManager.getMediaProjection(resultCode, data);
        android.util.Log.d("ScreenCaptureService", "MediaProjection created");

        DisplayMetrics metrics = new DisplayMetrics();
        WindowManager windowManager = (WindowManager) getSystemService(WINDOW_SERVICE);
        windowManager.getDefaultDisplay().getMetrics(metrics);

        virtualDisplay = mediaProjection.createVirtualDisplay("ScreenCapture",
                metrics.widthPixels, metrics.heightPixels, metrics.densityDpi,
                DisplayManager.VIRTUAL_DISPLAY_FLAG_AUTO_MIRROR,
                surface, null, null);
        android.util.Log.d("ScreenCaptureService", "VirtualDisplay created");

        // Capture the screen and save it as a Bitmap
        // ...

        return START_NOT_STICKY;
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        if (virtualDisplay != null) {
            virtualDisplay.release();
        }
        if (mediaProjection != null) {
            mediaProjection.stop();
        }
    }

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }
}