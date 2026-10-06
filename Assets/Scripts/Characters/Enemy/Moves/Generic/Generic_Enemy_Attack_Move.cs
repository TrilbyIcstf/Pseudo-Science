using System.Collections.Generic;
using UnityEngine;

public abstract class Generic_Enemy_Attack_Move : Enemy_Move
{
    // Move Effects
    public override List<MoveResult> ResultsCalc(Enemy_Stats ei, List<int> targets, float potency)
    {
        return GenericResultsCalc(ei, targets, potency);
    }

    public override MoveResult TargetCalc(Enemy_Stats ei, int target, float potency)
    {
        return GenericTargetCalc(ei, target, potency);
    }

    public override bool ApplyMove(Enemy_Stats ei, List<MoveResult> results)
    {
        return GenericApplyMove(ei, results);
    }
}
