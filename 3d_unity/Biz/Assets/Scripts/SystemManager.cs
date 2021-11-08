using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance = null;

    public static SystemManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    Player player;

    public Player Mel
    {
        get
        {
            return player;
        }
    }

    [SerializeField]
    ClothesManager clothesManager;
    public ClothesManager ClothesManager
    {
        get
        {
            return clothesManager;        
        }
    }

    [SerializeField]
    JobNameTitle jabnameTitle;
    public JobNameTitle JobNameTitle
    {
        get
        {
            return jabnameTitle;
        }
    }

    [SerializeField]
    InputController inputContrller;
    public InputController InputController
    {
        get
        {
            return inputContrller;
        }
    }

    [SerializeField]
    GamePointAccumulator gamePointAccumulator;
    public GamePointAccumulator GamePointAccumulator
    {
        get
        {
            return gamePointAccumulator;
        }
    }

    [SerializeField]
    ClothesSetting clothesSetting;
    public ClothesSetting ClothesSetting
    {
        get
        {
            return clothesSetting;
        }
    }

    [SerializeField]
    ButtonSystem buttonSystem;
    public ButtonSystem ButtonSystem
    {
        get
        {
            return buttonSystem;
        }
    }

    PrefabCacheSystem clothesCacheSystem = new PrefabCacheSystem();
    public PrefabCacheSystem ClothesCacheSystem
    {
        get
        {
            return clothesCacheSystem;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
