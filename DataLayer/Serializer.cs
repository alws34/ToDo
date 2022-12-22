using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DoYourTasks
{
    public class Serializer
    {
        public Serializer() { }
        string filepath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\ToDo\\ToDoDB.dat";

        public void Serialize(object data, bool toAppend = false) {

            IFormatter formatter = new BinaryFormatter();
            try
            {
                Stream stream = new FileStream(filepath, FileMode.Append, FileAccess.Write);
                formatter.Serialize(stream, data);
                stream.Close();
            }
            catch (Exception) { return; }
        }

        //public void JsonSerialize_(object data, bool toAppend = false)
        //{
        //    EvaluatePath(filepath);

        //    if (File.Exists(filepath))
        //        File.Delete(filepath);


        //    JsonSerializer jsonSerializer = new JsonSerializer();

        //    using (StreamWriter sw = new StreamWriter(filepath, toAppend))
        //    using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
        //        jsonSerializer.Serialize(jsonWriter, data);
        //}

        public object Deserialize(Type type, string filepath) {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            return (object)formatter.Deserialize(stream);

        }

        //public object JsonDeserialize_(Type type, string filepath)
        //{
        //    if (!File.Exists(filepath))
        //        return null;

        //    JObject obj = null;
        //    JsonSerializer jsonSerializer = new JsonSerializer();
        //    using (StreamReader sr = new StreamReader(filepath))
        //    using (JsonReader jsonReader = new JsonTextReader(sr))
        //        obj = jsonSerializer.Deserialize(jsonReader) as JObject;
        //    try
        //    {
        //        return obj.ToObject(type);
        //    }
        //    catch (Exception) { return null; }
        //}

        private void EvaluatePath(string path)
        {

            try
            {
                string folder = Path.GetDirectoryName(path);
                if (!Directory.Exists(folder))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(folder);
                }
            }
            catch (IOException ioex)
            {

            }
        }

        public string GetDBPath()
        {
            return filepath;
        }
    }
}
