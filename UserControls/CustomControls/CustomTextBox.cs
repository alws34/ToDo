using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYourTasks.UserControls.CustomControls
{
    public partial class CustomTextBox : UserControl
    {
        #region CustomEvents
        public delegate void gotHiddenEventHandler(bool isHidden, EventArgs arg);
        public event gotHiddenEventHandler gotHidden;
        #endregion

        #region Fields
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle = false;
        private bool isInCreationMode = false;
        #endregion

        #region Properties
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        public bool UnderlinedStyle
        {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }
        #endregion

        #region Constructors
        public CustomTextBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Getters
        public CustomTextBox GetCurrentCustomTextBox()
        {
            return this;
        }

        public string GetText()
        {
            return textBox.Text;
        }

        #endregion

        #region Setters
        public void SetText(string text)
        {
            textBox.Text = text;
        }

        public void SetTextBoxColor(Color backColor, Color textColor)
        {
            //textBox.BackColor = backColor;
            textBox.ForeColor = textColor;
        }

        public void SetTextBoxState()
        {
            if (textBox.Enabled)
                textBox.Enabled = false;
            else
                textBox.Enabled = true;
        }
        #endregion

        #region Events
        protected virtual void OnHide()
        {
            if (gotHidden != null)
                gotHidden(true, EventArgs.Empty);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //draw border 
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (underlinedStyle)
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else //normal style
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlheight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlheight();
        }

        private void UpdateControlheight()
        {
            if (textBox.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, txtHeight);
                textBox.Multiline = false;

                this.Height = textBox.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                Hide();
                OnHide();
            }
        }
        #endregion
    }
}
