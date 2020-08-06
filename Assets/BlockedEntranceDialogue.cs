﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedEntranceDialogue : Dialogue
{

    public Collider entranceCollider;

    protected override void onStart()
    {
        base.onStart();
    }

    protected override async void dialogue()
    {
        var type = PlayerSingleton.Instance.GetCurrentEquippedItemType();
        if (type == ItemType.EMPTY)
        {
            await this.showContinue("The planks wont budge. A tool of some sort is needed top open the door.");
            QuestHelper.Instance.SetText("Find something to open the doors");
        }
        else if(type == ItemType.SAW)
        {
            QuestHelper.Instance.SetText("");
            this.gameObject.GetComponent<InteractorShower>().disable();
            entranceCollider.gameObject.SetActive(true);
            PlayerSingleton.Instance.CurrentEquippedItem = PlayerSingleton.Instance.emptyItem;
            this.gameObject.SetActive(false);
        }
        else
        {
            await this.showContinue("This item wont work...");
        }

        end();
    }
}