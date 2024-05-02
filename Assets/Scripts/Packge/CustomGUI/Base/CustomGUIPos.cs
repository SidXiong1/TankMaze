using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 九宫格方位枚举
/// </summary>
public enum E_Alignment_Type
{
    Up,
    Down,
    Left,
    Right,
    Center,
    Left_Up,
    Left_Down,
    Right_Up,
    Right_Down
}
/// <summary>
/// 九宫格对齐
/// </summary>
[System.Serializable]
public class CustomGUIPos 
{
    private Rect rPos = new Rect(0, 0, 100, 100);

    public E_Alignment_Type screen_Alignment_Type = E_Alignment_Type.Center;
    public E_Alignment_Type controller_Alignment_Type = E_Alignment_Type.Center;

    public Vector2 pos;

    public float width = 100;
    public float height = 50;


    private Vector2 Center;

    private void CalPos()
    {
        switch (screen_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                rPos.x = Screen.width / 2;
                rPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                rPos.x = Screen.width / 2;
                rPos.y = Screen.height;
                break;
            case E_Alignment_Type.Left:
                rPos.x = 0;
                rPos.y = Screen.height / 2;
                break;
            case E_Alignment_Type.Right:
                rPos.x = Screen.width;
                rPos.y = Screen.height / 2;
                break;
            case E_Alignment_Type.Center:
                rPos.x = Screen.width / 2;
                rPos.y = Screen.height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                rPos.x = 0;
                rPos.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                rPos.x = 0;
                rPos.y = Screen.height;
                break;
            case E_Alignment_Type.Right_Up:
                rPos.x = Screen.width;
                rPos.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                rPos.x = Screen.width;
                rPos.y = Screen.height;
                break;
            default:
                break;
        }
        rPos.x = rPos.x + Center.x + pos.x;
        rPos.y = rPos.y + Center.y + pos.y;
    }
    private void CalCenterPos()
    {
        switch (controller_Alignment_Type)
        {
            case E_Alignment_Type.Up:
                Center.x = -width / 2;
                Center.y = 0;
                break;
            case E_Alignment_Type.Down:
                Center.x = -width / 2;
                Center.y = -height;
                break;
            case E_Alignment_Type.Left:
                Center.x = 0;
                Center.y = -height/2;
                break;
            case E_Alignment_Type.Right:
                Center.x = -width;
                Center.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                Center.x = -width / 2;
                Center.y = -height / 2;
                break;
            case E_Alignment_Type.Left_Up:
                Center.x = 0;
                Center.y = 0;
                break;
            case E_Alignment_Type.Left_Down:
                Center.x = 0;
                Center.y = -height;
                break;
            case E_Alignment_Type.Right_Up:
                Center.x = -width;
                Center.y = 0;
                break;
            case E_Alignment_Type.Right_Down:
                Center.x = -width;
                Center.y = -height;
                break;
            default:
                break;
        }
    }
    public Rect Pos
    {
        get
        {
            CalCenterPos();
            CalPos();
            rPos.width = width;
            rPos.height = height;
            return rPos;
        }
    }
}
