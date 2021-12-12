using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SprayController : MonoBehaviour
{
    [SerializeField]
    GameObject _wall;
    WallController wallController;

    public Define.SprayState State;
    void Start()
    {
        Init();
    }
    void Init()
    {
        State = Define.SprayState.Idle;
        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
        wallController = _wall.GetComponent<WallController>();
    }
    void Update()
    {
        switch(State)
        {
            case Define.SprayState.Spray:
                {
                    SprayAround();
                    break;
                }
        }

    }

    void OnMouseEvent(Define.MouseEvent evt)
    {
        
        switch(evt)
        {
            case Define.MouseEvent.Press:
                {
                    State = Define.SprayState.Spray;
                    break;
                }
            case Define.MouseEvent.PointerUp:
                {
                    State = Define.SprayState.Idle;
                    break;
                }
        }
    }


    void SprayAround()
    {
        Vector3 hitWallPoint = FindHitPoint();
        if(hitWallPoint.magnitude > 0)
        {
            wallController.SprayPointAround(hitWallPoint);
        }
    }

    Vector3 FindHitPoint()
    {
        // 카메라 forward 벡터로 RayCast
        Vector3 look = transform.TransformDirection(Camera.main.transform.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 30, Color.red);
        LayerMask mask = LayerMask.GetMask("Wall");
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 30, mask))
        {
            Debug.Log($"Raycast !! {hit.point}");
            return hit.point;
        }

        return Vector3.zero;
    }

}
