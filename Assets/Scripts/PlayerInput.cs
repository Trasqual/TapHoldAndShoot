using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 shootVector;
    private float maxY;
    private float maxZ;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var curY = shootVector.y;
            var curZ = shootVector.z;
            if(curY < maxY)
            {
                curY += Time.deltaTime;
            }
            else
            {
                curY = maxY;
            }

            if (curZ < maxY)
            {
                curZ += Time.deltaTime;
            }
            else
            {
                curZ = maxZ;
            }
        }
    }
}
