using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimestampEntity : MonoBehaviour
{
    public string myTime;

    private void Start()
    {
        SmoothSlider.OnSlide += SmoothSlider_OnSlide;
        this.gameObject.SetActive(false);
    }

    private void SmoothSlider_OnSlide(Timestamp timestamp)
    {
        Debug.Log("wew");
        if(timestamp.timestamp.Equals(myTime))
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
