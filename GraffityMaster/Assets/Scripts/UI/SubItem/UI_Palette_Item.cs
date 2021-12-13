using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Palette_Item : UI_Base
{

    SprayController spray;
    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name;
    Sprite _image;
    Define.PaletteColor _colorType;
    public override void Init()
    {
        spray = Managers.Game.GetPlayer().GetComponent<SprayController>();
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = $"{_name}";
        Get<GameObject>((int)GameObjects.ItemIcon).GetComponent<Image>().sprite = _image;
        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent(((PointerEventData data) => { spray.sprayColor = _colorType; }), Define.UIEvent.Click);
    }
    public void SetInfo(string name, Define.PaletteColor colorType)
    {
        _colorType = colorType;
        _name = name;
        _image = Managers.Resource.Load<Sprite>($"Sprite/PaletteColor/{name}");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
