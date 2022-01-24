using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhaseBase
{
    public PhaseBase next;
    public abstract IEnumerator Execute(Script_BattleManager.BattleContext battleContext);
    public bool StartBattle = false;
}