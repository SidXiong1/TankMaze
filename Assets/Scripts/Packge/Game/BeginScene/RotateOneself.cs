using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOneself : MonoBehaviour
{
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
