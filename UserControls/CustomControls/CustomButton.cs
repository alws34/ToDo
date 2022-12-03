using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace DoYourTasks.UserControls
{
    public class CustomButton : Button
    {
        private int borderSize = 0;
        private int borderRadius = 60;
        private Color borderColor = Color.PaleVioletRed;

        public CustomButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            Text = "CustomButton";
        }

        private GraphicsPath GetButtonPath(RectangleF rect, float radius)
        {
            GraphicsPath path= new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);//top left
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);//top right
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);//bottom right
            path.AddArc(rect.X, rect.Height- radius, radius, radius, 90, 90);//bottom left
            path.CloseFigure();
            return path;
        }
       
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2)
            { //rounded button
                using (GraphicsPath pathSurface = GetButtonPath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetButtonPath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);

                    //Draw Surface border for HD results
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    //Draw control border
                    if (borderSize > 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }

            }
            else
            {//regular 
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)//if you need to change the background color of the container and update the button, remove this.
                this.Invalidate();
        }
    }
}
