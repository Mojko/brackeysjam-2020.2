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

    private GameObject instance;

    private Transform parentCanvas;
    
    private Camera camera;
    private Text textField;

    public UnityEvent onVisible;
    
    // Start is called before the first frame update
    void Start()
    {
        this.parentCanvas = GameObject.FindGameObjectWithTag("DialogueCanvas").transform;
        this.instance = Instantiate(toShow,this.parentCanvas);
        this.textField = instance.transform.Find("Text").gameObject.GetComponent<Text>();
        this.textField.text = letter+"";
        this.camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.camera.WorldToScreenPoint(this.transform.position);
        this.instance.transform.position = pos;
    }
}
