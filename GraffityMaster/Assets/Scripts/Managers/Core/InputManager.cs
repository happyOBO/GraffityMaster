using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action MouseAction = null;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke(); // 누군가 구독중이면 구독중인것을 실행시켜라

        if (MouseAction != null)
            MouseAction.Invoke();
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
