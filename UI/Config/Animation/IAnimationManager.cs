// UI/Animation/IAnimationManager.cs

namespace VRMS.UI.Config.Animation
{
    public interface IAnimationManager : IDisposable
    {
        event EventHandler AnimationStarted;
        event EventHandler AnimationCompleted;

        bool IsAnimating { get; }
        void StartSlideAnimation();
        void StopAnimation();
    }
}