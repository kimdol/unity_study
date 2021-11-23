using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicBox : MonoBehaviour
{
    [SerializeField]
    SerializeDictionary<string, AudioClip> mAudioClip;

    private string mPlayMusicName = null;


    static MusicBox instance = null;
    public static MusicBox Instance
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
        // � �Է��� ���� �� �ش��ϴ� �Ҹ��� ������
        if (mPlayMusicName != null)
        {
            PlayMusic();
        }
        
    }

    private void PlayMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (!mAudioClip.ContainsKey(mPlayMusicName))
        {
            Debug.Log("none key");
            mPlayMusicName = null;
            return;
        }
        audio.clip = mAudioClip[mPlayMusicName];
        audio.Play();

        mPlayMusicName = null;
    }

    public void InputPlayMusicName(string musicName)
    {
        if (musicName != null)
        {
            mPlayMusicName = musicName;
        }

        return;
    }



}
