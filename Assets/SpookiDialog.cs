using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookiDialog : Dialogue
{

    public ItemData cobweb;
    
    protected override async void dialogue()
    {
        if (PlayerSingleton.Instance.hasTalkedToBlixtenAfterRats)
        {
            await this.showContinue("Cobweb","This looks like something sticky and stringy.");
            PlayerSingleton.Instance.CurrentEquippedItem = cobweb;
            this.gameObject.GetComponent<InteractorShower>().disable();
            this.gameObject.SetActive(false);
            end();
            return;
        }

        await this.showContinue("Cobweb","Spooki");
        SmoothSlider.Instance.EnableTimestamp(1);
        end();
    }
}
