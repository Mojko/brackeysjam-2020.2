using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFadeout : MonoBehaviour
{
    private static CameraFadeout instance;
    public static CameraFadeout Instance => instance;

    public Material cameraFadeout;
    private float fadeoutTimer = 0f;
    private bool fadeout;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(!this.fadeout)
        {
            return;
        }

        this.cameraFadeout.color = new Color(0,0,0, fadeoutTimer);
        fadeoutTimer += Time.deltaTime * 0.3f;
    }

    public void FadeOut()
    {
        this.fadeout = true;
        this.fadeoutTimer = 0f;
    }
}
