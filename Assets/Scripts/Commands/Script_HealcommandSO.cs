using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Script_HealcommandSO : Script_commandSO
{
    [SerializeField] new int HealPoint;

    //commandSO‚ÌExecuteã‘‚«
    public override void Execute(Script_Battle user, Script_Battle target)
    {
        target.hp += HealPoint;
    }
}
