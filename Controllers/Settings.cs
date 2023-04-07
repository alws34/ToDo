using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class Settings
    {
        private Utils Utils = new Utils();
        public Theme SavedTheme { get; set; } = null;


        public Settings(){}
    }
}
