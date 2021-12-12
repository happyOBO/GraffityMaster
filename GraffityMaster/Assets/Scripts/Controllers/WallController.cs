using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    Material _material;

    public int WallMinX = -100;
    public int WallMinY = 0;

    public int WIDTH = 200;
    public int HEIGHT = 30;
    Texture2D maskTexture;

    
    void Start()
    {
        Init();
    }

    void Init()
    {
        Renderer _renderer = gameObject.GetComponent<Renderer>();
        _material = gameObject.GetComponent<Renderer>().material;
        maskTexture = Texture2D.blackTexture;
        maskTexture.Resize(WIDTH, HEIGHT);
        // Black Texture로 한번더 초기화
        for (int i = 0; i < WIDTH; i++)
            for (int j = 0; j < HEIGHT; j++)
                maskTexture.SetPixel(i, j, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        maskTexture.Apply();
        _material.SetTexture("_MaskTex", maskTexture);
    }

    
    void Update()
    {
    }

    public void SprayPointAround(Vector3 point)
    {
        Vector3Int PixelPosition = PointToPixelPosition(point);
        for (int i = PixelPosition.x ; i < PixelPosition.x + 2  ; i++)
            for (int j = PixelPosition.y ; j < PixelPosition.y + 2 ; j++)
                maskTexture.SetPixel(i, j, new Color(1.0f, 0.0f, 0.0f, 0.0f));
        maskTexture.Apply();
        _material.SetTexture("_MaskTex", maskTexture);
    }

    Vector3Int PointToPixelPosition(Vector3 point)
    {
        return new Vector3Int((int)point.x - WallMinX, (int)point.y - WallMinY, 0);
    }
}
