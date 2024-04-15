using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AA
{
	public float m_structFloat = 20;

    //public AA()
    //{
    //    m_structFloat = 0.0f;
    //}
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/New Item")]
public class Field : ScriptableObject
{
    [SerializeField]
    private string nameeee;

    public AA aa;
}
