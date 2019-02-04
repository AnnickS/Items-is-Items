using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStateAskFor : QuestState
{
    private Dialog dialog;
    private string text;
    bool showedDialog = false;

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
        showedDialog = true;
    }

    public override void FixedUpdate()
    {
        if(showedDialog && !dialog.isShowing())
        {
            done();
        }
    }
}
