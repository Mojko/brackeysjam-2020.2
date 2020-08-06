using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlixtenDialogue : Dialogue
{

    public ItemData cat;
    
    // Start is called before the first frame update
    protected override async void dialogue()
    {
        if (PlayerSingleton.Instance.GetCurrentEquippedItemType() == ItemType.COBWEB)
        {
            await this.showContinue("Meow");
            PlayerSingleton.Instance.CurrentEquippedItem = PlayerSingleton.Instance.emptyItem;
            PlayerSingleton.Instance.CurrentEquippedItem = cat;
            this.GetComponent<InteractorShower>().disable();
            this.gameObject.SetActive(false);
            QuestHelper.Instance.SetText("Find something to remove the rats.");
            end();
            return;
        }

        if (PlayerSingleton.Instance.talkedToRats)
        {
            await this.showContinue("Hiss");
            QuestHelper.Instance.SetText("Find a way to befriend Blixten");
            PlayerSingleton.Instance.hasTalkedToBlixtenAfterRats = true;
            end();
            return;
        }

        await this.showContinue("Hiss");
        end();
        return;
    }
}
