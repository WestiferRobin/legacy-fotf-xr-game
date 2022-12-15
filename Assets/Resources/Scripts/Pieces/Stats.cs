using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public int HealthPoints { get; }
    public int MovePoints { get; }
    public int RangePoints { get; }
    public int AttackPoints { get; }
    public int DefencePoints { get; }

    public Stats(int hp, int move, int range, int attack, int defence)
    {
        this.HealthPoints = hp;
        this.MovePoints = move;
        this.RangePoints = range;
        this.AttackPoints = attack;
        this.DefencePoints = defence;
    }
}
