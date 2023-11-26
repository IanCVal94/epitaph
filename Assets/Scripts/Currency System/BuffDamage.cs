using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[CreateAssetMenu]
public class BuffDamage : Item
{
    [SerializeField]
    private float extraDamage = 10;

    public override void firstActivation(Player player)
    {
        Debug.Log("Increasing damage by: " + extraDamage);
        player.Attack.currentBaseValue += extraDamage;
    }

    public override void disableStatic(Player player)
    {
        player.Attack.currentBaseValue -= extraDamage;
    }
}
