using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTransition : MonoBehaviour
{
    private static BabyTransition instance;
    public static BabyTransition Instance => instance;
    public static event BabyTransitionEvent OnMove;
    public delegate void BabyTransitionEvent(bool to, GameObject old);
    public static event BabyTransitionEvent OnBabyTransition;

    public GameObject SliderUI;

    public GameObject stefansHouse;

    private bool isInBabyWorld = false;

    private Vector3 oldPlayerPos;

    private TimestampEntity prevEnt;

    private bool isInsideStefan = false;
    
    void Start()
    {
        instance = this;
    }

    void Update()
    {
    }

    public void Transition()
    {
        oldPlayerPos = PlayerSingleton.Instance.gameObjectInstance.transform.position;
        isInBabyWorld = true;
        OnMove.Invoke(false,null);
        StartCoroutine(moveToBabyScene());
        isInsideStefan = stefansHouse.activeSelf;
        stefansHouse.SetActive(false);            
    }

    IEnumerator moveToBabyScene()
    {
        yield return new WaitForSeconds(0.20f);
        SliderUI.SetActive(false);
        PlayerSingleton.Instance.gameObjectInstance.ChangePosition(BabyScene.Instance.location.transform.position);
        prevEnt = TimestampEntity.getEntity(SmoothSlider.Instance.getCurrentTimestamp().timestamp);
        OnBabyTransition.Invoke(true, null);
    }

    public void GoBackToOldPosition()
    {
        isInBabyWorld = false;
        OnMove.Invoke(false,null);
        SmoothSlider.Instance.SlideToTimestamp(SmoothSlider.Instance.getCurrentTimestamp().index);
        StartCoroutine(moveToOldScene());
        //GameObject = DropHelper.getTimestampObject(SmoothSlider.Instance.getCurrentTimestamp());
    }
    
    IEnumerator moveToOldScene()
    {
        yield return new WaitForSeconds(0.20f);
        PlayerSingleton.Instance.gameObjectInstance.ChangePosition(oldPlayerPos);
        if(isInsideStefan)
            stefansHouse.SetActive(true);
        else
            SliderUI.SetActive(true);
        OnBabyTransition.Invoke(false,isInsideStefan ? null : prevEnt.gameObject);
        SmoothSlider.Instance.EnableTimestamp(4);
        prevEnt = null;
    }


}
