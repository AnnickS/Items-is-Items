using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateDialog : QuestState
{
    protected Dialog dialog;
    protected bool showedDialog = false;

    public override void Initialize(GameObject questGiver)
    {
        dialog = questGiver.GetComponentInChildren<Dialog>(true);

        if (dialog == null)
        {
            Debug.LogError("QuestStateDialog Object could not find a Dialog");
        }
    }

    public override void ShowStory()
    {
        dialog.setText(text);
        dialog.show();
        showedDialog = true;
    }

    public override bool IsDone()
    {
        if (showedDialog)
        {
            return true;
        }

        return false;
    }
}
