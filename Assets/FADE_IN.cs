using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FADE_IN : MonoBehaviour
{
    private float waitTimer = 1f;
    private RawImage img;
    public float speed = 2;
    public bool fadeOut = false;

    private bool fading = false;
    private void Start()
    {
        img = this.GetComponent<RawImage>();
        if (!fadeOut)
            fading = true;
    }

    private Color fadeIntarget = new Color(0, 0, 0, 1);

    void Update()
    {
        if(waitTimer <= 0 && fading)
        {
            if (!fadeOut)
            {
                if (img.color.a > 0.03f)
                    img.color = Color.Lerp(img.color, new Color(159f / 255f, 50f / 255f, 50 / 255f, 0),
                        Time.deltaTime * speed);
                else
                    Destroy(this.gameObject);
            }
            else
            {
                if (img.color.a < 0.97f)
                    img.color = Color.Lerp(img.color, fadeIntarget,
                        Time.deltaTime * speed);
                else
                    SceneManager.LoadScene("Jesper_CreditsScene");   
            }
        }
        else
        {
            waitTimer -= Time.deltaTime;
        }
    }

    public void startFadeIn()
    {
        fading = true;
        this.gameObject.SetActive(true);
    }
}
