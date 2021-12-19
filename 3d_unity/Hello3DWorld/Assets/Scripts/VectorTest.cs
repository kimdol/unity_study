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

        // ��Į���
        Vector3 v11 = new Vector3(1, 1, 1);
        Vector3 v22 = v11 * scalar;

        Handles.color = Color.white;
        Handles.DrawLine(Vector3.zero, v11, 2.0f);

        Handles.color = Color.yellow;
        Handles.DrawLine(Vector3.zero, v22);

        // ���� ũ�⸦ ȭ�鿡 ���
        Handles.Label(v22 * 0.5f, v22.magnitude.ToString());

        // ����ȭ - ������ ���̸� 1�� ����� ��
        Vector3 v111 = new Vector3(3, 3, 3);
        Vector3 v222 = v111.normalized;   // �ʵ�
                                          //Vector3 v222 = v111.Normalize();   //�Լ�

        Handles.color = Color.white;
        Handles.DrawLine(Vector3.zero, v1, 2.0f);

        
    }
}
