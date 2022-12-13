﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DoYourTasks.UserControls
{
    public class CustomRadioButton : RadioButton
    {
        private Color checkedColor = Color.MediumSlateBlue;
        private Color unCheckedColor = Color.Gray;

        public Color CheckedColor
        {
            get
            {
                return checkedColor;
            }
            set
            {
                checkedColor = value;
                this.Invalidate();
            }
        }

        public Color UnCheckedColor
        {
            get
            {
                return unCheckedColor;
            }
            set
            {
                unCheckedColor = value;
                this.Invalidate();
            }
        }

        public CustomRadioButton()
        {
            SetMinimumSize();
            this.MouseEnter += CustomRadioButton_MouseEnter;
            this.MouseLeave += CustomRadioButton_MouseLeave;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
        }


        public CustomRadioButton(string text, object tag = null)
        {
            SetMinimumSize();
            Text = text;
            Tag = tag;//this is a reference to the actual task.
        }

        public void Rename(string text)
        {
            Text = text.Replace("\r", "").Replace("\n", "");
        }

        #region Events
        private void CustomRadioButton_MouseLeave(object sender, EventArgs e)
        {
        }

        private void CustomRadioButton_MouseEnter(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 18F;
            float rbCheckSize = 12F;
            byte labelPosOffset = 4;
            Font = new Font("Arial", 14);
            //ForeColor= Color.White;

            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2, //center
                Width = rbBorderSize,
                Height = rbBorderSize
            };

            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //center
                Y = (this.Height - rbCheckSize) / 2,//center
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            //Drawing
            using (Pen penBorder = new Pen(checkedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                graphics.Clear(this.BackColor);//draw surface 
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);//circle border
                    graphics.FillEllipse(brushText, rectRbCheck);//circle Radio Checked
                }
                else
                {
                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder, rectRbBorder);//circle border
                }
                graphics.DrawString(this.Text, this.Font, brushText, rbBorderSize + 8,
                    (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height - labelPosOffset));//Y=Center
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + 30;
        }

        private void SetMinimumSize()
        {
            this.MinimumSize = new Size(0, 21);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {


        }

        #endregion
    }
}