using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SCript_attackcommandSO : Script_commandSO
{
    [SerializeField] new int AttackPoint;

    public override void Execute(ForBattleDate user, ForBattleDate target, WindowLog Log)
    {
        target.hp -= AttackPoint;
        
    }
}
