using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_SLider_Type
{
    horizontal,
    vertical
}
public class CustomGUISlider : CustomGUIControl
{
    public float maxValue = 1;
    public float minValue = 0;
    public float nowValue = 0;
    public E_SLider_Type sType = E_SLider_Type.horizontal;
    public GUIStyle buttonStyle;

    public event UnityAction<float> sliderChange;
    private float oldValue = 0;
    protected override void StyleOffDraw()
    {
        switch (sType)
        {
            case E_SLider_Type.horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            case E_SLider_Type.vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            default:
                break;
        }
        if (oldValue != nowValue)
        {
            sliderChange?.Invoke(nowValue);
            oldValue = nowValue;
        }
    }

    protected override void StyleOnDraw()
    {
        switch (sType)
        {
            case E_SLider_Type.horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, buttonStyle);
                break;
            case E_SLider_Type.vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, buttonStyle);
                break;
            default:
                break;
        }
        if (oldValue != nowValue)
        {
            sliderChange?.Invoke(nowValue);
            oldValue = nowValue;
        }
    }
}
