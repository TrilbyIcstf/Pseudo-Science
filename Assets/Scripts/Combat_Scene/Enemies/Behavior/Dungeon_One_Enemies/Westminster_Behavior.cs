using UnityEngine;

public class Westminster_Behavior : Behavior_Dad
{
    public override int GenerateIntent(Enemy_Stats stats)
    {
        bool halfHealth = (float)stats.CurrentHealth / (float)stats.MaxHealth <= 0.5f;

        int speed;
        if (halfHealth)
        {
            if (step % 2 == 0)
            {
                speed = 1;
                intent = new EnemyMoveIntent(EnemyMoveName.TremorBreak, MoveType.DEBUFF, TargetingType.Random, 2, 35);
            } else
            {
                speed = 4;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.LowestHealth, 4, 65);
            }
        } else
        {
            if (step % 2 == 0)
            {
                speed = 4;
                intent = new EnemyMoveIntent(EnemyMoveName.BasicSlash, MoveType.PHYSICAL, TargetingType.Random, 1, 110);
            }
            else
            {
                speed = 6;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.LowestHealth, 4, 65);
            }
        }

        step++;
        return speed;
    }
}
