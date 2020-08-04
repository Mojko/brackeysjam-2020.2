using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FADE_IN : MonoBehaviour
{
    private float waitTimer = 1f;

    void Update()
    {
        if(waitTimer <= 0)
        {
            if (this.GetComponent<RawImage>().color.a > 0)
                this.GetComponent<RawImage>().color = Color.Lerp(this.GetComponent<RawImage>().color, new Color(159f / 255f, 50f / 255f, 50 / 255f, 0), Time.deltaTime);
            else
                Destroy(this);
        }
        else
        {
            waitTimer -= Time.deltaTime;
        }
    }
}
