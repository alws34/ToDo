using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;


namespace DoYourTasks
{
    public class Serializer
    {
        public Serializer() { }
        string  filepath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\ToDoMock.json";
       
        public void JsonSerialize_(object data)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();

            if (File.Exists(filepath))
                File.Delete(filepath);

            using (StreamWriter sw = new StreamWriter(filepath))
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
    }
}
