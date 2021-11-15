using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpansionPanel : BasePanel
{
    private Sprite mSprite;
    public override void InitializePanel()
    {
        base.InitializePanel();
        base.Close();
    }

    public void ShowExpansionPanel(Sprite sp)
    {
        mSprite = sp;
        base.Show();
        // Ȯ��� �̹����� ���̱�
        transform.GetChild(0).GetComponent<Image>().sprite = mSprite;
    }

    public void OnOK()
    {
        base.Close();
    }
}
