using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{

    public Animator nuke;

    public float fadeSpeed = 2;
    
    public Image blackFade;

    private bool animateInBlack = false;

    private float target = 1;

    public Color targetColor;
    
    // Start is called before the first frame update
    void Start()
    {
        //targetColor = new Color(blackFade.color.r,blackFade.color.g,blackFade.color.b,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (animateInBlack)
        {
            blackFade.color = Color.Lerp(blackFade.color, targetColor, Time.deltaTime * fadeSpeed);
            if (blackFade.color.a > 0.99)
            {
                print("GO TO NEW SCENE");
                animateInBlack = false;
            }
        }
    }

    public void onStartMenuClicked()
    {
        nuke.SetTrigger("animate");
        blackFade.gameObject.SetActive(true);
        StartCoroutine(waitAnimate());
    }
    
    private IEnumerator waitAnimate()
    {
        yield return new WaitForSecondsRealtime(1f);
        animateInBlack = true;
    }

}
