﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeEnabler : MonoBehaviour
{

    public GameObject disable,enable;

    public Transform teleportTo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fade(Fader.onFade fadeCallback)
    {
        PlayerSingleton.Instance.occupied = true;
        Fader.Instance().fadeIn(4, () =>
        {
            disable.SetActive(false);
            enable.SetActive(true);
            PlayerSingleton.Instance.gameObjectInstance.ChangePosition(teleportTo.position);
            PlayerSingleton.Instance.occupied = false;
            Fader.Instance().fadeOut(4, () =>
            {
                fadeCallback?.Invoke();
            });
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        fade(null);
    }
}
