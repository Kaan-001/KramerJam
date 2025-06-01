
namespace Scenes.Scripts.BossFSM
{
    public interface IBossState
    {
        void Enter(Boss boss);
        void Update();
        void Exit();
    }
}
