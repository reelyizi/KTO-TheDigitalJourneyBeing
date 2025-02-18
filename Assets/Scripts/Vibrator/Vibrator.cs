using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vibrator
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer=new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity=unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator=currentActivity.Call<AndroidJavaObject>("getSystemService","vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif


    public static void Vibrate(long milisecond=250)
    {
        if(isAndroid())
        {
            vibrator.Call("vibrate",milisecond);
        }
        else
        {
#if UNITY_ANDROID && !UNITY_EDITOR          
            Handheld.Vibrate();
#endif
        }
    }
    public static void Cancel()
    {
        if(isAndroid())
        {
            vibrator.Call("cancel");
        }
    }

    public static bool isAndroid()
    {
#if UNITY_ANDROID
        return true;
#else
        return false;
#endif
        return false;
    }
}
