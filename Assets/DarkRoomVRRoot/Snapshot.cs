using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_ANDROID && !UNITY_EDITOR
using UnityEngine.Android;
#endif

public class Snapshot : MonoBehaviour
{
    [SerializeField]
    private RawImage displayImage; // Made non-readonly for assignment in Inspector.

    [SerializeField]
    private float screenshotInterval = 1.0f; // Made configurable in Inspector.

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Snapshot script started.");
        StartCoroutine(TakeScreenshotCoroutine());
    }

    private IEnumerator TakeScreenshotCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(screenshotInterval);
            Debug.Log("Screenshot interval elapsed.");

#if UNITY_ANDROID && !UNITY_EDITOR
            HandleAndroidScreenshot();
#else
            Debug.LogWarning("Screenshot functionality is only implemented for Android.");
#endif
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
private void HandleAndroidScreenshot()
{
    try
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        // Get the DisplayMetrics object and retrieve screen dimensions
        AndroidJavaObject displayMetrics = new AndroidJavaObject("android.util.DisplayMetrics");
        currentActivity.Call<AndroidJavaObject>("getWindowManager")
            .Call<AndroidJavaObject>("getDefaultDisplay")
            .Call("getMetrics", displayMetrics);

        int width = displayMetrics.Get<int>("widthPixels");
        int height = displayMetrics.Get<int>("heightPixels");

        Debug.Log($"Display width: {width}, height: {height}");

        // Start the service (if applicable)
        currentActivity.Call("startService", new AndroidJavaObject(
            "android.content.Intent", 
            currentActivity, 
            new AndroidJavaClass("com.connorhoehn.darkroomvr2.ScreenCaptureService")
        ));
    }
    catch (System.Exception ex)
    {
        Debug.LogError($"Error handling Android screenshot: {ex.Message}");
    }
}
#endif

    // Update is currently unused, can be removed if not required.
    void Update()
    {
    }
}
