namespace VRMS.UI.Config.Animation
{
    public class WelcomeFormAnimationManager : IAnimationManager
    {
        private readonly IAnimationHost _host;
        private readonly System.Windows.Forms.Timer _animationTimer; 

        private int _animationTime;
        private float _slideProgress;
        private bool _isAnimating;

        private const int TOTAL_ANIMATION_TIME = 800;
        private const int ANIMATION_INTERVAL = 16;

        public event EventHandler AnimationStarted;
        public event EventHandler AnimationCompleted;

        public bool IsAnimating => _isAnimating;

        public WelcomeFormAnimationManager(IAnimationHost host)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));

            _animationTimer = new System.Windows.Forms.Timer 
            {
                Interval = ANIMATION_INTERVAL
            };
            _animationTimer.Tick += OnAnimationTick;
        }

        public void StartSlideAnimation()
        {
            if (_isAnimating) return;

            _isAnimating = true;
            _animationTime = 0;
            _slideProgress = 0;

            _host.OnAnimationStart();
            AnimationStarted?.Invoke(this, EventArgs.Empty);
            _animationTimer.Start();
        }

        public void StopAnimation()
        {
            _animationTimer.Stop();
            _isAnimating = false;
        }

        private void OnAnimationTick(object sender, EventArgs e)
        {
            _animationTime += _animationTimer.Interval;

            if (_animationTime < TOTAL_ANIMATION_TIME)
            {
                _slideProgress = _animationTime / (float)TOTAL_ANIMATION_TIME;
                UpdateAnimationFrame();
            }
            else
            {
                CompleteAnimation();
            }
        }

        private void UpdateAnimationFrame()
        {
            float eased = EasingFunctions.EaseOutCubic(_slideProgress);
            _host.UpdateAnimationFrame(eased, _slideProgress);
        }

        private void CompleteAnimation()
        {
            _animationTimer.Stop();
            _isAnimating = false;

            _host.OnAnimationComplete();
            AnimationCompleted?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            _animationTimer?.Stop();
            _animationTimer?.Dispose();
        }
    }
}