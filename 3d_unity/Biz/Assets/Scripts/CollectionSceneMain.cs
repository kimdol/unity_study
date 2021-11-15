using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSceneMain : BaseSceneMain
{
    [SerializeField]
    NextScrollManager nextScrollManager;
    public NextScrollManager NextScrollManager
    {
        get
        {
            return nextScrollManager;
        }
    }

    public void GotoTitleScene()
    {
        // �ý��� �Ŵ����� �ı�
        DestroyImmediate(SystemManager.Instance.gameObject);
        SceneController.Instance.LoadSceneImmediate(SceneNameConstants.TitleScene);

    }
}
