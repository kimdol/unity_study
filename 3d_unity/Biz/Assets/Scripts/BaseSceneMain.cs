using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSceneMain : MonoBehaviour
{
    private void Awake()
    {
        OnAwake();
    }
    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScene();
    }

    private void OnDestroy()
    {
        Terminate();
    }

    protected virtual void OnAwake()
    {

    }
    protected virtual void OnStart()
    {

    }
    // �ܺο��� �ʱ�ȭ �ϱ� ���� �Լ�
    public virtual void Initialize()
    {

    }
    protected virtual void UpdateScene()
    {

    }
    protected virtual void Terminate()
    {

    }
}
