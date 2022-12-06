using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class Utils
    {
        public Utils() { }
        
        public string GetUniqueID()
        {//calculates a hash (sha512) -- (*ID*) based on current datetime milliseconds
            byte[] result = default;
            Random rnd = new Random();
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true)) {
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
    }
}
