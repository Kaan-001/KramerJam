using UnityEngine;

namespace Scenes.Scripts.BossFSM
{
    public class BossIdleState : IBossState
    {
        private Boss boss;
        public void Enter(Boss boss)
        {
            Debug.Log("Entering Idle State");
            this.boss = boss;
        }

        public void Update()
        {
            Debug.Log("Updating Idle State");
            boss.GetReadySkill();
        }

        public void Exit()
        {
            Debug.Log("Exiting Idle State");
        }
    }
}
