using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{

    protected override void Init()
    {
        List<GameObject> testpool = new List<GameObject>();
        base.Init();
        sceneType = Define.Scene.Login;

        for(int i = 0; i < 5;i++)
        {
            testpool.Add(Managers.Resource.Instantiate("UnityChan"));
        }

        foreach(GameObject obj in testpool)
        {
            Managers.Resource.Destroy(obj);
        }
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
        Debug.Log("Login Scene Clear");
    }
}
