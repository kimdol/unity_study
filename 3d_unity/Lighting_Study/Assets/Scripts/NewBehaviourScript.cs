using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldVertex = transform.TransformPoint(vertices[i]);
            Gizmos.DrawSphere(worldVertex, 0.1f);
            UnityEditor.Handles.Label(worldVertex, worldVertex.ToString());
        }
    }
}
