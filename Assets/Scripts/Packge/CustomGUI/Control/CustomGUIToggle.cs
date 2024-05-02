using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIToggle : CustomGUIControl
{
    public bool isSel;
    private bool isOldSel;
    public event UnityAction<bool> OnValueChange;

    protected override void StyleOffDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content);
        if (isOldSel != isSel)
        {
            OnValueChange?.Invoke(isSel);
            isOldSel = isSel;
        }
    }

    protected override void StyleOnDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content,style);
        if (isOldSel != isSel)
        {
            OnValueChange?.Invoke(isSel);
            isOldSel = isSel;
        }
    }
}
