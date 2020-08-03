using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTransition : MonoBehaviour
{
    private static BabyTransition instance;
    public static BabyTransition Instance => instance;

    public delegate void BabyTransitionEvent();
    public static event BabyTransitionEvent OnBabyTransition;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Transition");
            Transition();
        }
    }

    public void Transition()
    {
        PlayerSingleton.Instance.gameObjectInstance.ChangePosition(BabyScene.Instance.location.transform.position);
        OnBabyTransition.Invoke();
    }
}
