package com.connorhoehn.darkroomvr2;

import java.nio.ByteBuffer;

public interface IDisplayCaptureReceiver {
    void onNewImage(ByteBuffer byteBuffer, int width, int height, long timestamp);
}