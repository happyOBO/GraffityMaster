using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScene : BaseScene
{

    protected override void Init()
    {
        List<GameObject> testpool = new List<GameObject>();
        base.Init();
        sceneType = Define.Scene.Lobby;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }
    public override void Clear()
    {
        Debug.Log("Lobby Scene Clear");
    }
}
