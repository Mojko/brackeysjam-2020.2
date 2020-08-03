using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StefanDialogue : Dialogue
{
    protected override async void dialogue()
    {
        if(GlobalVariables.BrokeSquirrleDam)
        {
            await this.showContinue("You got rid of the squirrle dam? Thank you so much!");
            await this.showContinue("Do you have any questions to me?");
            await this.showContinue("My trip to Sweden? How come you're asking about that?");
            await this.showContinue("Oh well, the most noticeable part about it was that everyone was standing 5 feet apart from each other");
            await this.showContinue("Feels like they're social distancing by default");
            QuestHelper.Instance.SetText("");
            end();
            return;
        }

        if(GlobalVariables.HelpStefan)
        {
            await this.showContinue("There must be a way to break the squirrels dam...");
            end();
            return;
        }

        await this.showContinue("Wait a sec where did you come from! Eh whatever we don't have time with that. \n\nI don't know who you are but I've been living here alone for 10 years and I've been needing assistance for quite a while");
        await this.showContinue("You see, we've had a running problem here with SQUIRRLES. \n\nThey block our dams like beavers for some reason and make our water stop flowing");
        await this.showContinue("Will you be kind to let me know if you find out a way to deal with them?");
        QuestHelper.Instance.SetText("Find a way to deal with the squirrels for Stefan");
        GlobalVariables.HelpStefan = true;
        end();
    }
}
