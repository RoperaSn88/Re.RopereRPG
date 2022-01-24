using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Script_commandSO : ScriptableObject
{
    public new string name;
    public enum Targettype
    {
        Self,
        Enemy,
    }
    public Targettype Target;
    

    public virtual void Execute(Script_Battle user,Script_Battle target)
    {
        //target.hp -= at;
        //Debug.Log($"{user.name}‚ÌUŒ‚:{target.name}‚É3‚Ìƒ_ƒ[ƒW");
    }
}
