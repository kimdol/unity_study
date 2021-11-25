using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SpeedWagan : MonoBehaviour
{
    [SerializeField]
    List<string> keys;

    [SerializeField]
    List<TextAsset> values;

    private static SpeedWagan instance = null;
    public static SpeedWagan Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // �����ϰ� ������ �� �ֵ��� ���� ó��
        if (instance != null)
        {
            Debug.LogError("SystemManager is initialized twice!");
            Destroy(gameObject);
            return;
        }

        instance = this;

        // Scene �̵����� ������� �ʵ��� ó��
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �̸��� �´� Text�� ��Ž�帲
    public void WriteText(out string updateText, string jobName)
    {
        int index = JobNameToIndex(jobName);
        if ( index == -1)
        {
            updateText = null;
            return;
        }
        updateText = values[index].text;

    }
    // �����̸��� ���� index ������
    private int JobNameToIndex(string jobName)
    {
        int index = -1;

        index = keys.IndexOf(jobName);

        return index;
    }


}
