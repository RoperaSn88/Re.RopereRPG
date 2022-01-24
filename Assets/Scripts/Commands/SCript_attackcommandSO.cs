using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SCript_attackcommandSO : Script_commandSO
{
    [SerializeField] new int AttackPoint;

    public override void Execute(Script_Battle user, Script_Battle target)
    {
        target.hp -= AttackPoint;
        
    }
}
