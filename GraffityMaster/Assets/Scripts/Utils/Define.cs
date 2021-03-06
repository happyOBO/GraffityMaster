using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum PaletteColor
    {
        Red,
        Green,
        Blue,
        Texture,
        Eraser,
    }

    public enum SprayState
    {
        Idle,
        Spray,
    }
    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
        Wall,
    }
    public enum State
	{
		Die,
		Moving,
		Idle,
		Skill,
	}

public enum Layer
    {
        Monster = 8,
        Ground = 9,
        Block = 10,
    }
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum UIEvent
    {
        Click,
        Drag,
    }
    public enum MouseEvent
    {
        None,
        Press,
        PointerDown,
        PointerUp, 
        Click,
    }
    public enum CameraMode
    {
        QuarterView,
    }
}
