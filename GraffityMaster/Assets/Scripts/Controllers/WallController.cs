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

    Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
    
    void Start()
    {
        Init();
    }

    void Init()
    {
        Renderer _renderer = gameObject.GetComponent<Renderer>();
        _material = gameObject.GetComponent<Renderer>().material;
        InitTexture("_MaskTex");
        InitTexture("_ColorTex");
    }

    void InitTexture(string TextureName)
    {
        Texture2D texture = Texture2D.blackTexture;
        texture.Resize(WIDTH, HEIGHT);
        // Black Texture로 한번더 초기화
        for (int i = 0; i < WIDTH; i++)
            for (int j = 0; j < HEIGHT; j++)
                texture.SetPixel(i, j, new Color(0.0f, 0.0f, 0.0f, 0.0f));
        texture.Apply();
        _material.SetTexture(TextureName, texture);
        _textures.Add(TextureName, texture);
    }
    
    void Update()
    {
    }

    public void SprayPointAround(Vector3 point, Define.PaletteColor sprayColor)
    {
        Debug.Log($"{sprayColor}");
        switch(sprayColor)
        {
            case Define.PaletteColor.Red:
                {
                    SetPixels(new Color(1.0f, 0.0f, 0.0f, 0.0f),
                              PointToPixelPosition(point),
                              _textures["_ColorTex"], "_ColorTex");
                    break;
                }
            case Define.PaletteColor.Green:
                {
                    SetPixels(new Color(0.0f, 1.0f, 0.0f, 0.0f),
                              PointToPixelPosition(point),
                              _textures["_ColorTex"], "_ColorTex");
                    break;
                }
            case Define.PaletteColor.Blue:
                {
                    SetPixels(new Color(0.0f, 0.0f, 1.0f, 0.0f),
                              PointToPixelPosition(point),
                              _textures["_ColorTex"], "_ColorTex");
                    break;
                }
            case Define.PaletteColor.Texture:
                {
                    SetPixels(new Color (0.0f, 0.0f, 0.0f, 1.0f), 
                              PointToPixelPosition(point),
                              _textures["_MaskTex"], "_MaskTex");
                    break;
                }
            case Define.PaletteColor.Eraser:
                {
                    SetPixels(new Color(0.0f, 0.0f, 0.0f, 0.0f),
                              PointToPixelPosition(point),
                              _textures["_ColorTex"], "_ColorTex");
                    break;
                }
        }

    }

    void SetPixels(Color color, Vector3Int PixelPosition, Texture2D texture, string textureName)
    {
        for (int i = PixelPosition.x; i < PixelPosition.x + 2; i++)
            for (int j = PixelPosition.y; j < PixelPosition.y + 2; j++)
                texture.SetPixel(i, j, color);
        texture.Apply();
        _material.SetTexture(textureName, texture);
    }

    Vector3Int PointToPixelPosition(Vector3 point)
    {
        return new Vector3Int((int)point.x - WallMinX, (int)point.y - WallMinY, 0);
    }
}
