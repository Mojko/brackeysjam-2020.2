using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractorShower : MonoBehaviour
{

    public float radius;

    public char letter;

    public GameObject toShow;
    public Transform origin;

    private GameObject instance;

    private Transform parentCanvas;

    private Transform target;
    
    private Camera camera;
    private Text textField;
    private KeyCode keyCode;
    private bool inRange = false;

    public UnityEvent<bool> onVisible;
    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {
        this.parentCanvas = GameObject.FindGameObjectWithTag("DialogueCanvas").transform;
        this.instance = Instantiate(toShow,this.parentCanvas);
        this.textField = instance.transform.Find("Text").gameObject.GetComponent<Text>();
        this.textField.text = letter+"";
        this.camera = Camera.main;
        this.target = PlayerSingleton.Instance.getGameObject().transform;
        this.keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), letter+"");
        this.instance.SetActive(false);
    }

    private bool checkInRange()
    {
        return Vector3.Distance(this.target.position, this.transform.position) <= radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inRange && checkInRange())
        {
            inRange = true;
            this.instance.SetActive(true);
            onVisible.Invoke(true);
        }
        else if (inRange && !checkInRange())
        {
            inRange = false;
            this.instance.SetActive(false);
            onVisible.Invoke(false);
        }

        if (inRange)
        {
            Vector3 pos = this.camera.WorldToScreenPoint(this.origin.position);
            this.instance.transform.position = pos;
        }

        if (Input.GetKeyDown(keyCode) && inRange)
        {
            onInteraction.Invoke();
        }
    }
}
