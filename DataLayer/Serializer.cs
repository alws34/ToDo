using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;


namespace DoYourTasks
{
    public class Serializer
    {
        public Serializer() { }
        string  filepath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\ToDo\\ToDoMock.json";
        
        public void JsonSerialize_(object data, bool toAppend = false)
        {
            EvaluatePath(filepath);

            if (File.Exists(filepath))
                File.Delete(filepath);


            JsonSerializer jsonSerializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(filepath, toAppend))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonSerializer.Serialize(jsonWriter, data);
                }
            }
        }

        public object JsonDeserialize_(Type type, string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(filepath))
            {
                using (JsonReader jsonReader = new JsonTextReader(sr))
                {
                    obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                }
            }
            return obj.ToObject(type);
        }

        private void EvaluatePath(String path)
        {

            try
            {
                String folder = Path.GetDirectoryName(path);
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

        public string GetDBPath() {
            return filepath;
        }
    }
}
