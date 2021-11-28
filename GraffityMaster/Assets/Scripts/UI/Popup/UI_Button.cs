using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{


    int _score = 0;


    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    enum GameObjects
    {
        TestObjects,
    }

    enum Images
    {
        ItemIcon,
    }
    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetText((int)Texts.ScoreText).text = "GET 함수 테스트";

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        BindEvent(go, ((PointerEventData data) => { go.transform.position = data.position; }), Define.UIEvent.Drag);

        GetButton((int)Buttons.PointButton).gameObject.BindEvent(((PointerEventData data) => { _score++; GetText((int)Texts.ScoreText).text = $"score : {_score}"; }));

    }



    public void OnButtonClicked()
    {
        _score++;

    }
}
