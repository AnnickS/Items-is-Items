using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateDialog : QuestState
{
    protected Dialog dialog;
    protected bool showedDialog = false;
    protected bool isDone = false;

    public override void Initialize(GameObject questGiver)
    {
        dialog = questGiver.GetComponentInChildren<Dialog>(true);

        if (dialog == null)
        {
            Debug.LogError("QuestStateDialog Object could not find a Dialog");
        }
        else
        {
            dialog.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if(showedDialog && dialog.isShowing() == false)
        {
            isDone = true;
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
        return isDone;
    }
}
