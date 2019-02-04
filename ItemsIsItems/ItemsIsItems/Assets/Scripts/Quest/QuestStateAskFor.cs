using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateAskFor : QuestState
{
    private Dialog dialog;
    private string text;

    public QuestStateAskFor(Dialog dialog, string text)
    {
        this.dialog = dialog;
        this.text = text;
    }

    public override void Initialize()
    {
        dialog.setText(text);
    }

    public override void OnQuestGiverClicked()
    {
        dialog.show();
    }

    void FixedUpdate()
    {
        
    }
}
