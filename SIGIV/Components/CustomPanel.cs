using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGIV.Components
{
    public class CustomPanel : Panel
    {
        private int borderRadius = 10;
        private int shadow = 10;

        [Category("Appearance")]
        [Description("The radius of the border corners.")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("BorderRadius must be non-negative.");
                borderRadius = value;
                Invalidate(); // Redraw the panel when the border radius changes
            }
        }

        [Category("Appearance")]
        [Description("The size of the shadow around the panel.")]
        public int Shadow
        {
            get { return shadow; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Shadow must be non-negative.");
                shadow = value;
                Invalidate(); // Redraw the panel when the shadow changes
            }
        }

        public CustomPanel()
        {
            this.Resize += CPanal_Resize;
            this.DoubleBuffered = true; // Reduce flickering
        }

        private void CPanal_Resize(object sender, EventArgs e)
        {
            Invalidate(); // Redraw the panel when it is resized
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath grPath = new GraphicsPath())
            {
                grPath.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                grPath.AddArc(Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                grPath.AddArc(Width - borderRadius, Height - borderRadius, borderRadius, borderRadius, 0, 90);
                grPath.AddArc(0, Height - borderRadius, borderRadius, borderRadius, 90, 90);
                grPath.CloseAllFigures();
                this.Region = new Region(grPath);
            }

            // Draw shadow (optional)
            //if (shadow > 0)
            //{
            //    DrawShadow(e.Graphics);
            //}
        }

        private void DrawShadow(Graphics graphics)
        {
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, Color.Black)))
            {
                using (GraphicsPath shadowPath = new GraphicsPath())
                {
                    shadowPath.AddArc(shadow, shadow, borderRadius, borderRadius, 180, 90);
                    shadowPath.AddArc(Width - borderRadius - shadow, shadow, borderRadius, borderRadius, 270, 90);
                    shadowPath.AddArc(Width - borderRadius - shadow, Height - borderRadius - shadow, borderRadius, borderRadius, 0, 90);
                    shadowPath.AddArc(shadow, Height - borderRadius - shadow, borderRadius, borderRadius, 90, 90);
                    shadowPath.CloseAllFigures();

                    graphics.FillPath(shadowBrush, shadowPath);
                }
            }
        }
    }
}
