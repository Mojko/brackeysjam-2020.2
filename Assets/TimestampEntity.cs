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
        
        DropHelper.registerDropArea(myTime,this.gameObject);
        
    }

    private void SmoothSlider_OnSlide(Timestamp timestamp)
    {
        if(timestamp.timestamp.Equals(myTime))
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            print("setting to inactive:"+ myTime);
            this.gameObject.SetActive(false);
        }
    }
}
