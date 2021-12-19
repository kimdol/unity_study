using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorTest : MonoBehaviour
{
    public float scalar = 3.0f;

    private void OnDrawGizmos()
    {
        Vector3 v1 = new Vector3(1, 1, 1);
        Vector3 v2 = v1;

        v1.x = 2;

        Handles.color = Color.red;
        Handles.DrawLine(Vector3.zero, v1, 1.0f);

        Handles.color = Color.green;
        Handles.DrawLine(Vector3.zero, v2, 1.0f);

        // 스칼라곱
        Vector3 v11 = new Vector3(1, 1, 1);
        Vector3 v22 = v11 * scalar;

        Handles.color = Color.white;
        Handles.DrawLine(Vector3.zero, v11, 2.0f);

        Handles.color = Color.yellow;
        Handles.DrawLine(Vector3.zero, v22);

        // 벡터 크기를 화면에 출력
        Handles.Label(v22 * 0.5f, v22.magnitude.ToString());

        // 정규화 - 벡터의 길이를 1로 만드는 것
        Vector3 v111 = new Vector3(3, 3, 3);
        Vector3 v222 = v111.normalized;   // 필드
                                          //Vector3 v222 = v111.Normalize();   //함수

        Handles.color = Color.white;
        Handles.DrawLine(Vector3.zero, v1, 2.0f);

        
    }
}
