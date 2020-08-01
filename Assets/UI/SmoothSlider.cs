using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SmoothSlider : MonoBehaviour
{
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
            OnSlide.Invoke(this.timestamps[this.slideIndex]);
        }
    }

    private void Start()
    {
        slidingBackground.OnSlidingBackgroundClick += new SlidingBackground.SlidingBackgroundClickEvent(OnSlidingBackgroundClick);
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

        handleRect.anchorMin = Vector2.Lerp(handleRect.anchorMin, new Vector2(timestamps[slideIndex].rectTransform.anchorMin.x, handleRect.anchorMin.y), 0.01f);
        handleRect.anchorMax = Vector2.Lerp(handleRect.anchorMax, new Vector2(timestamps[slideIndex].rectTransform.anchorMax.x, handleRect.anchorMax.y), 0.01f);
    }

    public void SlideToTimestamp(int index)
    {
        slideIndex = index;
        Sliding = true;
    }
}