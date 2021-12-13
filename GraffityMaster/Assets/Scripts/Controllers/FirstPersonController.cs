using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSpeed = 3.0f; // 마우스 회전 속도
    public float moveSpeed = 10.0f; // 이동 속도
    Camera mainCamera;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        mainCamera = Camera.main;

        Managers.Input.MouseAction -= MouseRoatate;
        Managers.Input.MouseAction += MouseRoatate;
        Managers.Input.KeyAction -= KeyboardMove;
        Managers.Input.KeyAction += KeyboardMove;
    }
    void Update()
    {
    }

    void MouseRoatate(Define.MouseEvent evt)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float yRotateSize = Input.GetAxis("Mouse X") * mouseSpeed;
            float xRotateSize = -Input.GetAxis("Mouse Y") * mouseSpeed;

            transform.localRotation *= Quaternion.Euler(0.0f, yRotateSize, 0.0f);
            mainCamera.transform.localRotation *= Quaternion.Euler(xRotateSize, 0.0f, 0.0f);
        }
    }

    void KeyboardMove()
    {
        if(Input.GetKey(KeyCode.LeftShift) )
        {
            Vector3 dir = new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
            );
            transform.Translate(dir * moveSpeed * Time.deltaTime);

        }
    }
}