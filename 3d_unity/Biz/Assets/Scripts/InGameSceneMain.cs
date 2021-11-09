using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneMain : BaseSceneMain
{
    const float GameReadyIntaval = 3.0f;

    public enum GameState : int
    {
        Ready = 0,
        Running,
        End
    }

    GameState currentGameState = GameState.Ready;
    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
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

    [SerializeField]
    ItemBoxManager itemBoxManager;
    public ItemBoxManager ItemBoxManager
    {
        get
        {
            return itemBoxManager;
        }
    }

    PrefabCacheSystem itemBoxCacheSystem = new PrefabCacheSystem();
    public PrefabCacheSystem ItemBoxCacheSystem
    {
        get
        {
            return itemBoxCacheSystem;
        }
    }


    [SerializeField]
    Transform mainBGQuadTransform;

    public Transform MainBGQuadTransform
    {
        get
        {
            return mainBGQuadTransform;
        }
    }

    public void OnGameEnd(bool success)
    {
        
    }
    float SceneStartTime;
    protected override void OnStart()
    {
        SceneStartTime = Time.time;
    }
    protected override void UpdateScene()
    {
        base.UpdateScene();

        float currentTime = Time.time;

        if (currentGameState == GameState.Ready)
        {
            if (currentTime - SceneStartTime > GameReadyIntaval)
            {
                /* Game Start!! */
            }
        }
    }

}
