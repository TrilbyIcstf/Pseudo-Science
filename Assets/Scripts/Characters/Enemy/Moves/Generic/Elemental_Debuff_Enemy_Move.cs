using System.Collections.Generic;
using UnityEngine;

public class Elemental_Debuff_Enemy_Move : Enemy_Move
{
    [SerializeField]
    private Element element;

    [SerializeField]
    private StatusEffect statusEffect;
    [SerializeField]
    private int duration;

    public override bool ApplyMove(Enemy_Stats ei, List<MoveResult> results)
    {
        foreach (MoveResult result in results)
        {
            int target = result.TargetNum;
            float damage = result.Potency;
            GameManager.instance.combat.ProcessEnemyAttackDamage(target, (int)damage);
            GameManager.instance.party.ApplyStatus(target, statusEffect, duration, true);
            Combat_UI_Commands.RefreshHealthBars();
            Combat_UI_Commands.UpdateStatusIcons();
        }
        return true;
    }

    public override Element GetElement()
    {
        return element;
    }

    public override MoveType GetMoveType()
    {
        return MoveType.DEBUFF;
    }

    public override bool IsMoveFinished()
    {
        return moveStarted && particleControllerList.Count <= 0;
    }

    public override void EndMove(int user) { }

    public override void StartMove(int user, List<MoveResult> results)
    {
        foreach (MoveResult result in results)
        {
            GameObject tempParticleController = Instantiate(mainParticleController);
            tempParticleController.GetComponent<Bullet_Spray_Particle_Controller>().Setup(Combat_UI_Commands.GetEnemyPosition(user), Combat_UI_Commands.GetPlayerPosition(result.TargetNum).position, this, new List<MoveResult>() { result }, 2);
            GameManager.instance.fx.AddParticleManager(tempParticleController);
        }
        moveStarted = true;
    }

    public override List<MoveResult> ResultsCalc(Enemy_Stats ei, List<int> targets, float potency)
    {
        return GenericResultsCalc(ei, targets, potency);
    }

    public override MoveResult TargetCalc(Enemy_Stats ei, int target, float potency)
    {
        return GenericTargetCalc(ei, target, potency, MoveType.MAGICAL);
    }
}
