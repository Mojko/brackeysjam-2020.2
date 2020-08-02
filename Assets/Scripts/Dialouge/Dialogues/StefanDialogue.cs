using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StefanDialogue : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("Hello fellow stranger");
        end();
    }
}
