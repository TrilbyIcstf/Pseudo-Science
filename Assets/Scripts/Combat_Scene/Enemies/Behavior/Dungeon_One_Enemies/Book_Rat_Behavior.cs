using UnityEngine;

public class Book_Rat_Behavior : Behavior_Dad
{
    public override (GameObject, TargetingType, int, int, float) MakeMove()
    {
        step++;

        EnemyMoveIntent currentIntent = intent;

        int speed = 0;
        switch (varient)
        {
            case 0:
                speed = 2;
                intent = new EnemyMoveIntent(EnemyMoveName.BasicSlash, MoveType.PHYSICAL, TargetingType.Random, 1, 35);
                break;
            case 1:
                speed = 6;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.LowestHealth, 4, 55);
                break;
            case 2:
                speed = 8;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.Random, 1, 125);
                break;
            default: throw new System.NotImplementedException();
        }

        GameObject moveObject = GameManager.instance.ll.enemyMoveRepository.GetValue(currentIntent.Move);

        return (moveObject, currentIntent.TargetingType, currentIntent.Targets, speed, currentIntent.Potency);
    }

    public override int GenerateBaseIntent()
    {
        int speed = 0;
        switch (varient)
        {
            case 0:
                speed = 2;
                intent = new EnemyMoveIntent(EnemyMoveName.BasicSlash, MoveType.PHYSICAL, TargetingType.Random, 1, 55);
                break;
            case 1:
                speed = 4;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.LowestHealth, 4, 85);
                break;
            case 2:
                speed = 5;
                intent = new EnemyMoveIntent(EnemyMoveName.SparkBurst, MoveType.MAGICAL, TargetingType.Random, 1, 185);
                break;
            default: throw new System.NotImplementedException();
        }
        return speed;
    }
}
