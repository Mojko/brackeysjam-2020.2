using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueEntry entry;

    private DialogueEntry instance;
    
    void Start()
    {
        instance = entry.setup(GameObject.FindGameObjectWithTag("DialogueEntryCanvas"));
        this.instance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showDialogue(string text)
    {
        this.instance.setText(text);
        this.instance.gameObject.SetActive(true);
    }
}
