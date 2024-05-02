using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGUIToggleGroup : MonoBehaviour
{
    public CustomGUIToggle[] toggles;
    private CustomGUIToggle frontToggle;
    void Start()
    {
        if (toggles == null)
        {
            return;
        }
        else
        {
            for(int i = 0; i < toggles.Length; i++)
            {
                CustomGUIToggle toggle = toggles[i];
                toggles[i].OnValueChange += (value)=>{
                    if (value)
                    {
                        for(int j = 0; j < toggles.Length; j++)
                        {
                            if (toggles[j] != toggle)
                            {
                                toggles[j].isSel = false;
                            }
                        }
                        frontToggle = toggle;
                    }
                    else
                    {
                        if (frontToggle == toggle)
                        {
                            toggle.isSel = true;
                        }
                    }
                };
            }
        }
    }
}
