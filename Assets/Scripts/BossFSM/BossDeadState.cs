using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.Scripts.BossFSM
{
    public class BossDeadState : IBossState
    {
        public void Enter(Boss boss)
        {
            boss.isActive = false;
            SceneManager.LoadScene(3);
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}
