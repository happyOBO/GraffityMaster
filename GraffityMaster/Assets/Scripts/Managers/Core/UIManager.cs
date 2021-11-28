﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10;
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;


    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");

            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }
    // 외부에서 팝업 UI 가 켜질때 정리
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }

        else
        {
            canvas.sortingOrder = 0;
        }


    }


    public T MakeWorldSpaceUI<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Managers.Resource.Instantiate($"UI/WorldSpace/{name}");

            if (parent != null)
                go.transform.SetParent(parent);

            Canvas canvas = go.GetOrAddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = Camera.main;

            return go.GetOrAddComponent<T>();
        }
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");

            if(parent != null)
                go.transform.SetParent(parent);

            return go.GetOrAddComponent<T>();
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
    }


    // name : prefab 이름 , T 는 컴포넌트의 스크립트 이름, 보통 둘이 동일함
    // name 이 null 이면 T를 사용
    // Popup UI를 스택에 추가
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        // ex ) UI_Button 프리팹에 UI_Button 스크립트 컴포넌트가 있는지 확인 없으면 추가
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;
        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed! ");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;
        UI_Popup popup = _popupStack.Pop();
        // ex ) UI_Button 스크립트 컴포넌트를 통해서 그의 gameObject Destroy
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }
    

    public void CloseAllPopUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
    public void Clear()
    {
        CloseAllPopUI();
        _sceneUI = null;
    }
}
