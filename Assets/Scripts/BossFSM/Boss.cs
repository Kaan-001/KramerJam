using System;
using UnityEngine;
using System.Collections.Generic;
using Scenes.Scripts.BossFSM;
using Unity.VisualScripting;

public class Boss : MonoBehaviour
{
    private IBossState currentState;
    
    [Header("Boss Health")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Skills")]
    public List<GameObject> skills;
    
    private List<BossSkill> activeSkills;
    
    public bool isActive;

    void Start()
    {
        isActive = true;
        activeSkills = new List<BossSkill>();
        currentHealth = maxHealth;

        // Her skill'i başlat
        foreach (var skill in skills)
        {
            var s = skill.GetComponent<BossSkill>();
            var component = gameObject.AddComponent(s.GetType()).GetComponent<BossSkill>();
            component.skillName = s.skillName;
            component.cooldown = s.cooldown;
            component.duration = s.duration;
            component.projectileCount = s.projectileCount;
            component.bossProjectile = s.bossProjectile;
            component.Init();
            
            activeSkills.Add(component);
        }

        ChangeState(new BossIdleState());
    }

    void Update()
    {
        Debug.Log(currentHealth);
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
        if (!isActive) { return null; }
        
        foreach (var skill in activeSkills)
        {
            if (skill.IsReady())
                return skill;
        }

        return null;
    }
}