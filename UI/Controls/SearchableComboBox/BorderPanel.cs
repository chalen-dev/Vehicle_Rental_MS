using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VRMS.UI.Controls
{
    public class BorderPanel : Panel
    {
        private Color _borderColor = Color.FromArgb(204, 204, 204);
        private int _borderWidth = 1;

        [Category("Appearance")]
        [Description("The color of the border.")]
        [DefaultValue(typeof(Color), "204, 204, 204")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("The width of the border.")]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get => _borderWidth;
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        public BorderPanel()
        {
            // Enable double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var pen = new Pen(_borderColor, _borderWidth))
            {
                var rect = new Rectangle(0, 0, Width - 1, Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}