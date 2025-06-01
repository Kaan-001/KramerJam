using UnityEngine;
using System.Collections.Generic;
using Scenes.Scripts.BossFSM;

public class Boss : MonoBehaviour
{
    private IBossState currentState;

    public Transform player;

    [Header("Boss Health")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Skills")]
    public List<BossSkill> skills;

    void Start()
    {
        currentHealth = maxHealth;

        // Her skill'i başlat
        foreach (var skill in skills)
        {
            skill.Init();
        }

        ChangeState(new BossIdleState());
    }

    void Update()
    {
        foreach (var skill in skills)
        {
            skill.UpdateCooldown(Time.deltaTime);
        }

        currentState?.Update();
    }

    public void ChangeState(IBossState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter(this);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            ChangeState(new BossDeadState());
        }
    }

    public BossSkill GetReadySkill()
    {
        foreach (var skill in skills)
        {
            if (skill.IsReady())
                return skill;
        }

        return null;
    }
}