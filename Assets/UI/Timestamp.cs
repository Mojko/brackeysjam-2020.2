using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timestamp : MonoBehaviour
{
    public int timestamp;
    [HideInInspector] public RectTransform rectTransform;

    private void Start()
    {
        this.rectTransform = GetComponent<RectTransform>();
        Debug.Log(this.rectTransform);
    }
}
