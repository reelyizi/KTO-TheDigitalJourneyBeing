using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TakeShareScreenShoot : MonoBehaviour
{
    public Image imageHolder1;
     private Sprite mySprite;
     public bool isTaked;
    public bool takedScreenShot=false;
    string path;
    // Start is called before the first frame update
    void Start()
    {
        isTaked=false;
        ShowPictureHolder(false);
    }
    private void ShowPictureHolder(bool visible)
    {
        imageHolder1.gameObject.SetActive(visible);
    }
    public void ScreenShot()
    {
        StartCoroutine(TakeScreenShoot());
    }
    IEnumerator TakeScreenShoot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D tx=new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,false);
        tx.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);
        tx.Apply();
        path=Path.Combine(Application.temporaryCachePath,"sharedImage.png");
        File.WriteAllBytes(path,tx.EncodeToPNG());
        mySprite=Sprite.Create(tx,new Rect(0,0,tx.width,tx.height),new Vector2(0.5f,0.5f),100);
        ShowPictureHolder(true);
        imageHolder1.sprite=mySprite;
        isTaked=true;
    }
    void Taked()
    {
        isTaked=true;
    }

    public void Share()
    {
        new NativeShare()
            .AddFile(path).
            SetSubject("This is my score.")
            .SetText("Check my score. Can you beat me in Space Dancer?")
            .Share();

    }
}
