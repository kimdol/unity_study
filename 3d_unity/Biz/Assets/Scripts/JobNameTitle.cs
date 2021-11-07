using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class JobNameTitle : MonoBehaviour
{
    [SerializeField]
    List<string> mJobNames;

    TextMesh mUpdateText;

    int JobMaxCnt;
    int mRandomIndex;


    // Start is called before the first frame update
    void Start()
    {
        JobMaxCnt = mJobNames.Count;
        ChangeText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Text �ٲٱ�
    public void ChangeText()
    {
        // ������ ���� �ϳ� pick
        // �� ������ �ε����� ���� ���ڿ� pick
        // text = �� ���ڿ�
        mRandomIndex = Random.Range(0, JobMaxCnt);
        mUpdateText = this.GetComponent<TextMesh>();
        mUpdateText.text = mJobNames[mRandomIndex];
        
    }
}
