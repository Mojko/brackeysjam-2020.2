using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTransition : MonoBehaviour
{
    private static BabyTransition instance;
    public static BabyTransition Instance => instance;
    public static event BabyTransitionEvent OnMove;
    public delegate void BabyTransitionEvent();
    public static event BabyTransitionEvent OnBabyTransition;

    public GameObject SliderUI;

    private bool isInBabyWorld = false;

    private Vector3 oldPlayerPos;
    
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
        OnMove.Invoke();
        StartCoroutine(moveToBabyScene());
    }

    IEnumerator moveToBabyScene()
    {
        yield return new WaitForSeconds(0.20f);
        SliderUI.SetActive(false);
        PlayerSingleton.Instance.gameObjectInstance.ChangePosition(BabyScene.Instance.location.transform.position);
        OnBabyTransition.Invoke();
    }

    public void GoBackToOldPosition()
    {
        isInBabyWorld = false;
        SliderUI.SetActive(true);
        SmoothSlider.Instance.SlideToTimestamp(SmoothSlider.Instance.getCurrentTimestamp().index);
        StartCoroutine(moveToOldScene());
        //GameObject = DropHelper.getTimestampObject(SmoothSlider.Instance.getCurrentTimestamp());
    }
    
    IEnumerator moveToOldScene()
    {
        yield return new WaitForSeconds(0.20f);
        PlayerSingleton.Instance.gameObjectInstance.ChangePosition(oldPlayerPos);
    }


}
