using UnityEngine;

namespace Scenes.Scripts.BossFSM
{
    public class BossDeadState : IBossState
    {
        public void Enter(Boss boss)
        {
            boss.isActive = false;
            Debug.Log("Boss Dead");
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}
