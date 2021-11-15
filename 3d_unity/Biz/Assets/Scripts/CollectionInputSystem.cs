using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CollectionInputSystem : MonoBehaviour
{
    // CollctionLeftBotton
    public void OnCollectionLeft()
    {
        CollectionSceneMain scene = SystemManager.Instance.GetCurrentSceneMain<CollectionSceneMain>();
        scene.NextScrollManager.scrollbar.value -= scene.NextScrollManager.Next;


    }
    // CollctionRightBotton
    public void OnCollectionRight()
    {
        CollectionSceneMain scene = SystemManager.Instance.GetCurrentSceneMain<CollectionSceneMain>();
        scene.NextScrollManager.scrollbar.value += scene.NextScrollManager.Next;


    }
    // Ȯ���� �г� ���̱�
    public void OnExpantionPanel()
    {
        ExpansionPanel panel = PanelManager.GetPanel(typeof(ExpansionPanel)) as ExpansionPanel;
        panel.ShowExpansionPanel(EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite);
    }
    // ó�� ȭ������ ����
    public void OnBack()
    {
        SystemManager.Instance.GetCurrentSceneMain<CollectionSceneMain>().GotoTitleScene();
    }
}
