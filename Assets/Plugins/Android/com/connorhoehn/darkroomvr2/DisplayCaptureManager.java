package com.connorhoehn.darkroomvr2;

import android.content.Intent;
import android.graphics.PixelFormat;
import android.media.ImageReader;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import android.app.Activity;

import com.unity3d.player.UnityPlayer;

import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.List;

public class DisplayCaptureManager implements ImageReader.OnImageAvailableListener {
    private static DisplayCaptureManager instance;
    private ByteBuffer byteBuffer;
    private ImageReader reader;
    private int width;
    private int height;

    private DisplayCaptureManager() {
        // Singleton Constructor
    }

    public static synchronized DisplayCaptureManager getInstance() {
        if (instance == null) {
            instance = new DisplayCaptureManager();
        }
        return instance;
    }

    public void setup(String gameObjectName, int width, int height) {
        this.width = width;
        this.height = height;
        int bufferSize = width * height * 4; // Assuming RGBA
        byteBuffer = ByteBuffer.allocateDirect(bufferSize);

        reader = ImageReader.newInstance(width, height, PixelFormat.RGBA_8888, 2);
        reader.setOnImageAvailableListener(this, new Handler(Looper.getMainLooper()));
    }

    public void requestCapture() {
        Intent intent = new Intent(UnityPlayer.currentActivity, DisplayCaptureRequestActivity.class);
        UnityPlayer.currentActivity.startActivity(intent);
    }

    public void stopCapture() {
        if (reader != null) {
            reader.close();
        }
    }

    public void onPermissionResponse(int resultCode, Intent intent) {
    if (resultCode == Activity.RESULT_OK) {
        Log.i("DisplayCaptureManager", "Permission granted.");
        // Handle permission granted
    } else {
        Log.e("DisplayCaptureManager", "Permission denied.");
        // Handle permission denied
    }
}


    @Override
    public void onImageAvailable(ImageReader imageReader) {
        if (imageReader == null) return;

        ByteBuffer buffer = imageReader.acquireLatestImage().getPlanes()[0].getBuffer();
        buffer.rewind();
        byteBuffer.clear();
        byteBuffer.put(buffer);

        Log.i("DisplayCapture", "Image captured!");
    }

    public ByteBuffer getByteBuffer() {
        return byteBuffer;
    }
}
