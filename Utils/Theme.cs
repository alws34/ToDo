using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class Theme
    {
        public Color ForeColor { get; }
        public Color BackColor { get; }
        public Color SecondBackColor { get; }
        public Theme(Color foregroundColor, Color backColor, Color secondBackColor)
        {
            ForeColor = foregroundColor;
            BackColor = backColor;
            SecondBackColor = secondBackColor;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Theme other = (Theme)obj;
            return ForeColor == other.ForeColor && BackColor == other.BackColor && SecondBackColor == other.SecondBackColor;
        }
        public List<Color> GetThemeColors() { return new List<Color> { ForeColor, BackColor, SecondBackColor }; }
    }
}
