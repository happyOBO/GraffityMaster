using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Palette : UI_Scene
{
    enum GameObjects
    {
        GridPanel,

    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);

        // 기존에 붙여 놓았던 UI_Inven_Item 삭제

        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
        
        Array paletteColors = Enum.GetValues(typeof(Define.PaletteColor));
        foreach(Define.PaletteColor color in paletteColors)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Palette_Item>(parent: gridPanel.transform).gameObject;
            UI_Palette_Item invenItem = item.GetOrAddComponent<UI_Palette_Item>();
            invenItem.SetInfo($"{color.ToString()}", color);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
