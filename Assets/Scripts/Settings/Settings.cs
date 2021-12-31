using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public FillBar[] fillBars;
    void Start()
    {
        foreach (FillBar item in fillBars)
        {
            Debug.Log(item.baseVolume.GetComponent<RectTransform>().rect.width);
            Debug.Log(item.area.GetComponent<RectTransform>().sizeDelta);
            Debug.Log(item.area.GetComponent<RectTransform>().anchorMax);
            Debug.Log(item.area.GetComponent<RectTransform>().offsetMax);
            Debug.Log(item.area.GetComponent<RectTransform>().offsetMin);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FillBar item in fillBars)
        {
            Debug.Log(item.area.GetComponent<RectTransform>().anchoredPosition);
            item.knob.position = new Vector3(item.baseVolume.GetComponent<Image>().fillAmount > 0.5f ? (item.baseVolume.GetComponent<RectTransform>().rect.width / 2) * item.baseVolume.GetComponent<Image>().fillAmount : (-item.baseVolume.GetComponent<RectTransform>().rect.width / 2) * item.baseVolume.GetComponent<Image>().fillAmount, 0, 0) + item.baseVolume.transform.position;
        }
    }
}
