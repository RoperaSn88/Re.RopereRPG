using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Script_HealItemSO : Script_commandSO
{
    [SerializeField] int HealPoint;
    public override void Execute(ForBattleDate user, ForBattleDate target, WindowLog Log)
    {
        target.hp += HealPoint;
        Debug.Log($"{name}‚ðŽg—p");
        user.UseItem(this);
    }
}
