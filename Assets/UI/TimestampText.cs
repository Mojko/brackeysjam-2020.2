using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimestampText : TextMeshProUGUI
{
    private bool lerp;
    private float from;
    private float to;

    public void onSmoothSliderSlide(Timestamp timestamp)
    {
        this.lerp = true;
        this.from = int.Parse(this.text);
        this.to = timestamp.timestamp;
    }

    private void Update()
    {
        if(!lerp)
        {
            return;
        }

        this.from = Mathf.Lerp(this.from, this.to, 0.01f);
        this.text = Mathf.RoundToInt(this.from).ToString();
    }
}
