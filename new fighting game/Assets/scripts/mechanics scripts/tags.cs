using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tags
{
    public static float check;
    public static float enemyattack=0;
    public static bool changeno = true;
    public static bool MoveOnWall = true;
    public static bool PlayerDead = false;
    public static bool EnemyDead = false;
    
}

public enum state
{
    walk, attack, beingattacked
}