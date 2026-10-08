using UnityEngine;

public class Book_Rat_Behavior : Behavior_Dad
{
    public override int GenerateIntent(Enemy_Stats stats)
    {
        int speed;
        switch (varient)
        {
            case 0:
                speed = 2;
                intent = new EnemyMoveIntent(EnemyMoveName.BasicSlash, MoveType.PHYSICAL, TargetingType.Random, 1, 35);
                break;
            case 1:
                speed = 4;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.LowestHealth, 4, 55);
                break;
            case 2:
                speed = 2;
                intent = new EnemyMoveIntent(EnemyMoveName.TremorBreak, MoveType.DEBUFF, TargetingType.Random, 1, 25);
                break;
            case 99:
                speed = 1;
                intent = new EnemyMoveIntent(EnemyMoveName.BasicSlash, MoveType.PHYSICAL, TargetingType.Random, 1, 999);
                break;
            default: throw new System.NotImplementedException();
        }

        step++;
        return speed;
    }
}
