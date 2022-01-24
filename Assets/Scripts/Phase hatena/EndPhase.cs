using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPhase : PhaseBase
{
    public override IEnumerator Execute(Script_BattleManager.BattleContext battleContext)
    {
        yield return null;
        Debug.Log("EndPhase");

    }
}
