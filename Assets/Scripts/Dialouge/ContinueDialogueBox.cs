using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueDialogueBox : MonoBehaviour
{
    
    public Text textField;
    
    public Text nameField;
    
    private ContinueDialogueBox instance;

    private Action callback;
    
    public void setup()
    {
        Transform parent = GameObject.FindGameObjectWithTag("DialogueEntryCanvas").transform;
        this.instance = Instantiate(this, parent);
        this.instance.gameObject.SetActive(false);
    }

    public GameObject getInstance()
    {
        return instance.gameObject;
    }
    
    // Start is called before the first frame update
    public void show(string name, string text)
    {
        this.instance.nameField.text = name;
        this.instance.textField.text = text;
        this.instance.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.callback();
        }
    }

    public void onClick(Action callback)
    {
        this.instance.callback = callback;
    }
}
