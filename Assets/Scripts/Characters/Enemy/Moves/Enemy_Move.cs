using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Move : Move_Dad
{
    [SerializeField]
    protected float potency;

    // Section for handling move effects
    public abstract List<MoveResult> ResultsCalc(Enemy_Stats ei, List<int> targets, float potency);
    public abstract MoveResult TargetCalc(Enemy_Stats ei, int target, float potency);
    public abstract bool ApplyMove(Enemy_Stats ei, List<MoveResult> results);
    public abstract MoveType GetMoveType();
    public abstract Element GetElement();

    protected MoveResult GenericTargetCalc(Enemy_Stats ei, int target, float potency, MoveType? damageTypeOverride = null)
    {
        MoveType damageType = damageTypeOverride ?? GetMoveType();

        float adjustedPotency = potency / 100;
        Player_Information pi = GameManager.instance.party.GetPlayer(target);
        List<Element> weakness = pi.Weakness;
        List<Element> strength = pi.Strength;
        Effectiveness effectiveness = GetElement().Evaluate(weakness, strength);

        float result = 0;
        if (damageType == MoveType.PHYSICAL)
        {
            result = GenericDamageCalc(adjustedPotency, ei.Power, pi.Defense, effectiveness);
        }
        else if (damageType == MoveType.MAGICAL)
        {
            result = GenericDamageCalc(adjustedPotency, ei.Intelligence, pi.Resistance, effectiveness);
        }

        return new MoveResult(result, Target.PC, target, effectiveness);
    }

    protected int GenericDamageCalc(float potency, int offense, int defense, Effectiveness effectiveness)
    {
        return base.BasicDamageCalc(potency, offense, defense, effectiveness, Target.ENEMY);
    }

    protected int DamageCalc(float potency, int offense, float offenseRatio, int defense, float defenseRatio, Effectiveness effectiveness)
    {
        return base.DamageCalc(potency, offense, offenseRatio, defense, defenseRatio, effectiveness, Target.ENEMY);
    }

    protected List<MoveResult> GenericResultsCalc(Enemy_Stats ei, List<int> targets, float potency)
    {
        List<MoveResult> results = new List<MoveResult>();
        foreach (int target in targets)
        {
            results.Add(TargetCalc(ei, target, potency));
        }
        return results;
    }

    protected bool GenericApplyMove(Enemy_Stats ei, List<MoveResult> results)
    {
        foreach (MoveResult result in results)
        {
            int target = result.TargetNum;
            float damage = result.Potency;
            GameManager.instance.combat.ProcessEnemyAttackDamage(target, (int)damage);
            Combat_UI_Commands.RefreshHealthBars();
        }
        return true;
    }
}
