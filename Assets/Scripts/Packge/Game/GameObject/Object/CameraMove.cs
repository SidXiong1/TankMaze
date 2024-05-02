using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetPlayer;
    private Vector3 v3;
    public int H;

    private void LateUpdate()
    {
        if (targetPlayer == null)
        {
            return;
        }
        else
        {
            v3.x = targetPlayer.position.x;
            v3.z = targetPlayer.position.z;
            v3.y = H;
            this.transform.position = v3;
        }
    }
}
