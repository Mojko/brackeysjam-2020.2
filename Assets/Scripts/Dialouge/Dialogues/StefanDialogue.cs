using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StefanDialogue : Dialogue
{

    private bool hasTalkedAboutNumbers = false;
    
    public NpcDialogue babyDialogue;
    
    protected override async void dialogue()
    {
        if(GlobalVariables.BrokeSquirrleDam)
        {
            if (hasTalkedAboutNumbers)
            {
                await this.showContinue("Thanks again for the help. Now i can finally enjoy the lake water");
                end();
                return;
            }

            await this.showContinue("You got rid of the squirrle dam? Thank you so much!");
            await this.showContinue("Do you have any questions to me?");
            await this.showContinue("The weird letters on the wall? How come you're asking about that?");
            await this.showContinue("Oh well, There was an old man living in this house before i moved in. The realtor said he was a former engineer at Ekorre Inc.");
            await this.showContinue(
                "When i moved in there were a bunch of weird number and equations on the wall. All i remembered is that there was a big <b>4</b> in the middle of the wall...");
            await this.showContinue(
                "There was also an equation beside it. From what i remember it started with 2x*2+... but the rest was erased. Maybe it was important or something. I dont know, i'm just a farmer.");
            QuestHelper.Instance.SetText("");
            end();
            hasTalkedAboutNumbers = true;
            await Task.Delay(2000);
            BabyTransition.Instance.Transition();
            await Task.Delay(2000);
            babyDialogue.onDialogueBegin();
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
