using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookiDialog : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("Spooki");
        SmoothSlider.Instance.EnableTimestamp(1);
        end();
    }
}
