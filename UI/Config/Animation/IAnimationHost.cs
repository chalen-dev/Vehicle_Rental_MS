// UI/Animation/IAnimationHost.cs

namespace VRMS.UI.Config.Animation
{
    public interface IAnimationHost
    {
        void OnAnimationStart();
        void UpdateAnimationFrame(float easedProgress, float rawProgress);
        void OnAnimationComplete();
    }
}