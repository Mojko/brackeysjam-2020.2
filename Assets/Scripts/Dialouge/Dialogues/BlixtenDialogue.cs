using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlixtenDialogue : Dialogue
{
    // Start is called before the first frame update
    protected override async void dialogue()
    {
        await this.showContinue("Meow");
        end();
        return;
    }
}
