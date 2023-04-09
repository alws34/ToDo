﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;


namespace DoYourTasks
{
    /// <summary>
    /// Place in this class all objects you want to save
    /// </summary>
    public class SaveObject
    {
        public Settings Settings { get; set; }
        public ConcurrentDictionary<string, Project> Project { get; set; }
        public SaveObject() { }
    }

    public class Serializer
    {
        public Serializer() { }
        string filepath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\ToDo\\ToDoMock.json";

        public void JsonSerialize_(object data, bool toAppend = false)
        {
            EvaluatePath(filepath);

            if (File.Exists(filepath))
                File.Delete(filepath);


            JsonSerializer jsonSerializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            using (StreamWriter sw = new StreamWriter(filepath, toAppend))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(sw))
                jsonSerializer.Serialize(jsonWriter, data);
        }

        public object JsonDeserialize_(Type type, string filepath)
        {
            if (!File.Exists(filepath))
                return null;
            ConcurrentDictionary<string, Project> projects = null;

            JObject obj = null;

            JsonSerializer jsonSerializer = new JsonSerializer()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };

            using (StreamReader sr = new StreamReader(filepath))
            using (JsonReader jsonReader = new JsonTextReader(sr))
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;

            try
            {
                if (obj == null)
                    return null;

                SaveObject sobj = (SaveObject)obj.ToObject(type);

                if (sobj.Project == null && sobj.Settings == null)//Handle old database structure
                {
                    projects = obj.ToObject<ConcurrentDictionary<string, Project>>();
                    sobj = new SaveObject();
                    sobj.Project = projects;
                    sobj.Settings = new Settings();
                    Utils u = new Utils();
                    sobj.Settings.SavedTheme = u.LightTheme;
                }
                return sobj;
            }
            catch (Exception) { return null; }
        }
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
