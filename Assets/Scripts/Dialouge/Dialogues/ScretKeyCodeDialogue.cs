using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScretKeyCodeDialogue : Dialogue
{

    public CodeSolver solver;

    private bool showedOpenText = false;
    
    protected override async void dialogue()
    {
        if (showedOpenText)
        {
            await this.showContinue("go saved the world");
            end();
            return;
        }

        if (PlayerSingleton.Instance.hasSolvedSafe)
        {
            await this.showContinue("You got it open, good!!");
            end();
            showedOpenText = true;
            return;
        }
        

        await this.showContinue("Before i leave this place for good I will leave my most priced possession. To open the safe I need a code, the code is my award winning equation.");
        QuestHelper.Instance.SetText("Find a way to open the Safe.");
        //CodeSolver.showSolution(123);
        end();
        solver.OnActivate();
    }
}
