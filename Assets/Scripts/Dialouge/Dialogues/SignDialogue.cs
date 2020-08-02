using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignDialogue : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("Due to lack of water by those goddamn squirrels, we had to close our family owned water Blacksmith. Was owned for over a hundred years. Rip Water Blacksmith 1800-1900 ");
        end();
    }
}
