using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitalizer : MonoBehaviour
{
    Vector3 pos;
    public float offset = 3f;


    void Update()
    {
        //Camera follow mouse when aiming
        pos = Input.mousePosition;
        pos.z = offset;
      
    }
}
