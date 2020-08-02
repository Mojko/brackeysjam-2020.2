using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverOpenScript : MonoBehaviour
{

    public Animator riverAnimator;
    public Animator stoneAnimator;

    public void startAnimation()
    {
        riverAnimator.SetBool("start",true);
        stoneAnimator.SetBool("start",true);
    }
}
