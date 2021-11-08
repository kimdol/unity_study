using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointAccumulator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 올바른 답을 찾으면 1, 아니면 0
    public bool IsItCorrect()
    {
        // 밑의 동작의 수월함을 위한 예외처리
        GameObject go = SystemManager.Instance.Mel.CrashedObject();
        if (!go)
        {
            Debug.Log("Crashed Gameobject is none");
            return false;
        }
        // "타이틀 이름"과 "player와 부딪힌 오브젝트 이름"을 비교 후
        // 맞으면 true, 틀리면 false
        if (SystemManager.Instance.JobNameTitle.GetComponent<TextMesh>().text.Contains(go.name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
