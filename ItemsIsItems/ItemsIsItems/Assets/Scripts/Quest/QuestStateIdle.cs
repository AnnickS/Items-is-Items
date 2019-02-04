using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateIdle : QuestState
{
    private Dialog dialog;
    private string text;

    public QuestStateIdle(Dialog dialog, string text)
    {
        this.dialog = dialog;
        this.text = text;
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Initialize()
    {
        dialog.setText(text);
    }

    public override void OnQuestGiverClicked()
    {
        dialog.show();
    }
}
