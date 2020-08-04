﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    private YesNoDialogueBox yesNoPrefab;
    private ContinueDialogueBox continuePrefab;
    private Action callbackWhenDone;
    private GameObject activeView;

    private static Dialogue activeDialogue;
    
    private string npcName;

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        //yesNoPrefab = DialogueCanvasManager.instance.getYesNo();
        continuePrefab = DialogueCanvasManager.instance.getContinue();
        onStart();
    }

    protected virtual void onStart()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void setupDialogue(string npcName, Action action)
    {
        this.npcName = npcName;
        callbackWhenDone = action;
        PlayerSingleton.Instance.occupied = true;
        activeDialogue = this;
        dialogue();
    }

    public static void forceQuitActiveDialogue()
    {
        activeDialogue?.end();
    }

    protected virtual void dialogue() { }

    public void end()
    {
        PlayerSingleton.Instance.occupied = false;
        if(this.activeView != null)
            this.activeView.SetActive(false);
        this.activeView = null;
        activeDialogue = null;
        callbackWhenDone.Invoke();
    }

    protected Task<bool> showYesNo(string msg)
    {
        return null;
        if(activeView != null)
            activeView.SetActive(false);
        activeView = yesNoPrefab.getInstance();
        TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>();
        yesNoPrefab.show(npcName,msg);
        yesNoPrefab.onClick((val) =>
        {
            tcs1.SetResult(val);
        });
        return tcs1.Task;
    }
    protected Task showContinue(string msg)
    {
        return showContinue(this.npcName, msg);
    }
    
    protected Task showContinue(string name, string msg)
    {
        TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>();
        if (Dialogue.activeDialogue == null)
        {
            tcs1.SetResult(true);
            return tcs1.Task;
        }

        if(activeView != null)
            activeView.SetActive(false);
        activeView = continuePrefab.getInstance();
        continuePrefab.show(name,msg);

        continuePrefab.onClick(() =>
        {
            tcs1.SetResult(true);
        });
        return tcs1.Task;
    }
}
