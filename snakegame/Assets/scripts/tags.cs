using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tags
{
    public static string Wall = "Walls";
    public static string FRUIT = "Fruits";
    public static string BOMB = "Bomb";
    public static string TAIL = "TAIL";
}

public class metrics
{
    public static float NODE = 0.25f;

}

public enum playerDirection{
    LEFT=0,
   UP=1,
   RIGHT=2,
   DOWN=3,
   COUNT=4
}