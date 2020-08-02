using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StefanDialogue : Dialogue
{
    protected override async void dialogue()
    {
        await this.showContinue("Wait a sec where did you come from! Eh whatever we don't have time with that. \n\nI don't know who you are but I've been living here alone for 10 years and I've been needing assistance for quite a while");
        await this.showContinue("You see, we've had a running problem here with SQUIRRLES. \n\nThey block our dams like beavers for some reason and make our water stop flowing");
        await this.showContinue("Will you be kind to let me know if you find out a way to deal with them?");
        end();
    }
}
