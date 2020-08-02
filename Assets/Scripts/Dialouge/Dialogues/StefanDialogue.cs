using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StefanDialogue : Dialogue
{
    protected override async void dialogue()
    {
        bool val = await this.showYesNo("Do you want to continue?");
        await this.showContinue(val ? "Cool, you're in!": "Oh okay, too bad!");
        end();
    }
}
