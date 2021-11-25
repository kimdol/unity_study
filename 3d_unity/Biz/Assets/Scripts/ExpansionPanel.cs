using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpansionPanel : BasePanel
{
    [SerializeField]
    Text mExplainText;

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
        // �����̱�
        JobExplain();
    }

    public void OnOK()
    {
        base.Close();
    }

    // �Ҹ� ��ư
    public void OnTTS()
    {
        MusicBox.Instance.InputPlayMusicName(mSprite.name);
    }

    // ���ǵ���� ����
    private void JobExplain()
    {
        string upDateText = null;
        string RecentlyName = mSprite.name;

        SpeedWagan.Instance.WriteText(out upDateText, RecentlyName);
        mExplainText.text = upDateText;

    }
}
