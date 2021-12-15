using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TouchKeyBoardController : MonoBehaviour
{
    TouchScreenKeyboard clavier;
    public static string username="";

    public void OpenKeyboard()
    {
        clavier=TouchScreenKeyboard.Open("",TouchScreenKeyboardType.Default);
    }
    void Update()
    {
        if(TouchScreenKeyboard.visible==false && clavier!=null)
        {
            if(clavier.done)
            {
                username=clavier.text;
                clavier=null;
            }
        }
    }
}
