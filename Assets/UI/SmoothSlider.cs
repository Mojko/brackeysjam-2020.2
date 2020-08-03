using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SmoothSlider : MonoBehaviour
{
    private static SmoothSlider instance;
    public static SmoothSlider Instance => instance;

    public delegate void SlideEvent(Timestamp timestamp);
    public static event SlideEvent OnSlide;

    public RectTransform handleRect;
    public Timestamp[] timestamps;
    public SlidingBackground slidingBackground;

    private int slideIndex;

    private bool sliding;
    private bool Sliding
    {
        get
        {
            return sliding;
        }
        set
        {
            sliding = value;
            
            if(OnSlide != null)
                OnSlide.Invoke(this.timestamps[this.slideIndex]);
        }
    }

    private void Start()
    {
        instance = this;
        slidingBackground.OnSlidingBackgroundClick += new SlidingBackground.SlidingBackgroundClickEvent(OnSlidingBackgroundClick);

        foreach (var timestamp in timestamps)
        {
            timestamp.gameObject.SetActive(false);
        }

        this.timestamps[0].gameObject.SetActive(true);
        //this.timestamps[1].gameObject.SetActive(true);
        //this.timestamps[2].gameObject.SetActive(true);
        this.SlideToTimestamp(0);
    }

    private void OnSlidingBackgroundClick(Vector2 position)
    {
        SlideToTimestamp(GetClosestTimestampToPosition(position));
    }

    private int GetClosestTimestampToPosition(Vector2 position)
    {
        var min_diff = new Vector2(float.MaxValue, float.MaxValue);
        int index = 0;
        int result_index = 0;

        foreach (var timestamp in timestamps)
        {
            if(timestamp.gameObject.activeInHierarchy == false)
            {
                continue;
            }

            var diff = new Vector2(timestamp.rectTransform.position.x, timestamp.rectTransform.position.y) - position;
            if(diff.magnitude <= min_diff.magnitude)
            {
                min_diff = diff;
                result_index = index;
            }

            index++;
        }

        return result_index;
    }

    public void Update()
    {
        if(!Sliding)
        {
            return;
        }

        if(slideIndex >= timestamps.Length || slideIndex < 0)
        {
            return;
        }

        handleRect.anchorMin = Vector2.Lerp(handleRect.anchorMin, new Vector2(timestamps[slideIndex].rectTransform.anchorMin.x, handleRect.anchorMin.y), 0.01f);
        handleRect.anchorMax = Vector2.Lerp(handleRect.anchorMax, new Vector2(timestamps[slideIndex].rectTransform.anchorMax.x, handleRect.anchorMax.y), 0.01f);
    }

    public void SlideToTimestamp(int index)
    {
        slideIndex = index;
        Sliding = true;
    }

    public void EnableTimestamp(int index)
    {
        Debug.Log(this.timestamps[index]);
        this.timestamps[index].gameObject.SetActive(true);
    }
}