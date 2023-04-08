using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DoYourTasks.Properties;

namespace DoYourTasks
{
    public class Utils
    {
        #region Constructors
        public Utils() { }

        #endregion

        #region Getters
        public string GetUniqueID()
        {//calculates a hash (sha512) -- (*ID*) based on current datetime milliseconds and a random number
            byte[] result = default;
            Random rnd = new Random();
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    writer.Write(DateTime.Now.Millisecond);
                    writer.Write(rnd.Next());
                }



                stream.Position = 0;

                using (var hash = SHA256.Create())
                {
                    result = hash.ComputeHash(stream);
                }
            }

            var text = new string[32];

            for (var i = 0; i < text.Length; i++)
            {
                text[i] = result[i].ToString("x2");
            }
            return string.Concat(text);
        }
        #endregion

        #region Themes
        public Theme DarkTheme = new Theme(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(24, 22, 43), Color.FromArgb(35, 30, 59));//dark
        public Theme LightTheme = new Theme(Color.FromArgb(0, 0, 0, 0), Color.FromArgb(209, 209, 209), Color.FromArgb(254, 254, 254));
        #endregion Themes

        #region Notification
        public enum NotificationType
        {
            Error,
            Success,
            Info,
            Warning,
            Question,
            None
        }
        public bool GetThemeMode(Theme theme)
        {
            List<Color> current = theme.GetThemeColors();
            List<Color> Light = LightTheme.GetThemeColors();
            for (int i = 0; i < current.Count; i++)
                if (current[i].ToArgb() != Light[i].ToArgb())
                    return false;
            return true;

        }
        public Image GetNotificationImages(NotificationType type, Theme theme)
        {
            bool ThemeMode = GetThemeMode(theme);

            switch (type)
            {
                case NotificationType.Error:
                    if (ThemeMode)
                        return Resources.Error_light_png;
                    return Resources.Error_png;
                    break;
                case NotificationType.Success:
                    if (ThemeMode)
                        return Resources.success_Light_png;
                    return Resources.success_png;
                    break;
                case NotificationType.Info:
                    if (ThemeMode)
                        return Resources.info_Light_png;
                    return Resources.info_png;
                    break;
                case NotificationType.Warning:
                    if (ThemeMode)
                        return Resources.warning_Light_png;
                    return Resources.warning_png;
                    break;
                case NotificationType.Question:
                    if (ThemeMode)
                        return Resources.question_Light_png;
                    return Resources.question_png;
                    break;
            }
            return null;
        }
        #endregion Notifications

        #region Modifiers
        public void RoundCorners(object sender, EventArgs e)
        {
            //System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
            //if (control == null)
            //    return;

            //GraphicsPath path = new GraphicsPath();
            //int radius = 20;
            //Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            //path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            //path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            //path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            //path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            //path.CloseFigure();
            //control.Region = new Region(path);
        }

        public List<Color> GetColorPallet(bool mode)
        {
            List<Color> themeLST = new List<Color>();
            if (mode)//Light
            {
                themeLST.Add(Color.White);
                themeLST.Add(Color.Black);
                themeLST.Add(Color.Black);
            }
            else//Dark
            {
                themeLST.Add(Color.FromArgb(24, 22, 43));//Dark Back
                themeLST.Add(Color.FromArgb(35, 30, 59));//Lighter BackGround
                themeLST.Add(Color.White);//Fore Color
            }
            return themeLST;
        }
        #endregion Modifiers
    }
}
