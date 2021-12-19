using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorTest : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3 v1 = new Vector3(1, 1, 1);
        Vector3 v2 = v1;

        v1.x = 2;

        Handles.color = Color.red;
        Handles.DrawLine(Vector3.zero, v1, 1.0f);

        Handles.color = Color.green;
        Handles.DrawLine(Vector3.zero, v2, 1.0f);
    }
}
