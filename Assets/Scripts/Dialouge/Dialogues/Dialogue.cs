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

    private string npcName;
    // Start is called before the first frame update
    void Start()
    {
        yesNoPrefab = DialogueCanvasManager.instance.getYesNo();
        continuePrefab = DialogueCanvasManager.instance.getContinue();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void setupDialogue(string npcName, Action action)
    {
        this.npcName = npcName;
        callbackWhenDone = action;
        dialogue();
    }

    protected virtual void dialogue() { }

    public void end()
    {
        this.activeView.SetActive(false);
        this.activeView = null;
        callbackWhenDone.Invoke();
    }

    protected Task<bool> showYesNo(string msg)
    {
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
        if(activeView != null)
            activeView.SetActive(false);
        activeView = continuePrefab.getInstance();
        TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>();
        continuePrefab.show(npcName,msg);
        continuePrefab.onClick(() =>
        {
            tcs1.SetResult(true);
        });
        return tcs1.Task;
    }
}