using System.Collections;
using System.Collections.Generic;
using BossFSM;
using Scenes.Scripts.BossFSM;
using UnityEngine;

public class BossFieldAttack : BossSkill
{
    public override void Trigger()
    {
        base.Trigger();
        StartCoroutine(AoeSequence());
    }
    
    private IEnumerator AoeSequence()
    {
        Debug.Log(player);
        for (int i = 0; i < 5; i++)
        {
            Vector2 targetPos = player.transform.position;
            GameObject aoe = Instantiate(bossProjectile, targetPos, Quaternion.identity);
            aoe.GetComponent<AoeZone>().Initialize(1);

            yield return new WaitForSeconds(1);
        }
    }
}
