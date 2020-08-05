﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDialogue : Dialogue
{

    public Collider entranceCollider;
    
    protected override async void dialogue()
    {
        var type = PlayerSingleton.Instance.GetCurrentEquippedItemType();
        if (type == ItemType.EMPTY)
        {
            await this.showContinue("The rats are blocking the way. Find a way to remove them.");
            QuestHelper.Instance.SetText("Find something to remove the rats.");
        }
        else if(type == ItemType.CAT)
        {
            QuestHelper.Instance.SetText("");
            this.gameObject.GetComponent<InteractorShower>().disable();
            entranceCollider.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            await this.showContinue("This item wont work...");
        }

        end();
    }
}
