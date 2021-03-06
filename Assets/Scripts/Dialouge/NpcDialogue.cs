﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{

    private bool readyForDialogue;

    public float rotationSpeed = 2;
    public DialogueManager manager;
    public string name = "Unamed";
    
    private bool inDialogue = false;
    private Vector3 startForward;
    // Start is called before the first frame update
    void Start()
    {
        startForward = this.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyForDialogue)
        {
            Transform lookAt = PlayerSingleton.Instance.getGameObject().transform;
            this.lookAt(lookAt.position);
        }
    }

    void lookAt(Vector3 Point)
    {
        
        Vector3 direction = transform.position - Point;
        Quaternion oldRot = transform.rotation;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        float dot = Vector3.Dot(startForward, this.transform.forward);
        if (dot < 0.6)
        {
            this.transform.rotation = oldRot;
            return;
        }

        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eulerRotation.y, 0);
    }

    public void onReadyDialogue(bool val)
    {
        readyForDialogue = val;
        PlayerSingleton.Instance.getGameObject().movementHandler.isNearNpc(val?this:null);
    }

    public void onDialogueBegin()
    {
        if (inDialogue) return;
        inDialogue = true;
        manager.showDialogue(name,() =>
        {
            inDialogue = false;
        });
    }

}
