using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Script_HealItemSO : Script_commandSO
{
    [SerializeField] int HealPoint;
    public override void Execute(Script_Battle user, Script_Battle target)
    {
        target.hp += HealPoint;
        Debug.Log($"{name}‚ðŽg—p");
        user.UseItem(this);
    }
}
