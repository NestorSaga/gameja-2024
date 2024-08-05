using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RouteStep
{
    public enum dir
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }
    public dir direction;

}
