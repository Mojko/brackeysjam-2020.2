using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiseman : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("Hello fellow stranger");
        end();
    }
}
