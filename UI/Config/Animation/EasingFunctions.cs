
namespace VRMS.UI.Config.Animation
{
    public static class EasingFunctions
    {
        public static float EaseOutCubic(float t) => 1 - (float)Math.Pow(1 - t, 3);
        public static float EaseOutQuad(float t) => 1 - (1 - t) * (1 - t);
    }
}