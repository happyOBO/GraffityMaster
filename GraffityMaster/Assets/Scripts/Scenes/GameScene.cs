using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    Coroutine co;
    protected override void Init()
    {
        base.Init();
        sceneType = Define.Scene.Game;
        Managers.UI.ShowSceneUI<UI_Palette>("UI_Palette");

        Dictionary<int,Data.Stat> dict = Managers.Data.StatDict;
        gameObject.GetOrAddComponent<CursorController>();

        GameObject wall = Managers.Game.Spawn(Define.WorldObject.Wall, "Wall");
        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "Player");
        player.GetComponent<SprayController>()._wall = wall;

    }

    public override void Clear()
    {

    }


}
