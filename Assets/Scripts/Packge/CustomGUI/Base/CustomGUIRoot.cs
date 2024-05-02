using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIControl[] controls;
    // Start is called before the first frame update
    void Start()
    {
        controls = this.GetComponentsInChildren<CustomGUIControl>();
    }

    private void OnGUI()
    {
        //if (!Application.isPlaying)
        //{
        //    controls = this.GetComponentsInChildren<CustomGUIControl>();
        //}
        controls = this.GetComponentsInChildren<CustomGUIControl>();
        for (int i = 0; i < controls.Length; i++)
        {
            controls[i].DrawGUI();
        }
    }
}
