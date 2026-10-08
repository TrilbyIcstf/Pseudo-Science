using UnityEngine;

public class Stained_Knight_Behavior : Behavior_Dad
{
    public override int GenerateIntent(Enemy_Stats stats)
    {
        int speed;
        switch (varient)
        {
            case 0 when step % 2 == 0:
            case 1 when step % 2 == 1:
                speed = 3;
                intent = new EnemyMoveIntent(EnemyMoveName.BasicSlash, MoveType.PHYSICAL, TargetingType.LowestHealth, 1, 125);
                break;
            case 1 when step % 2 == 0:
            case 0 when step % 2 == 1:
                speed = 6;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.LowestHealth, 2, 85);
                break;
            default: throw new System.NotImplementedException();
        }

        step++;
        return speed;
    }
}
