using Newtonsoft.Json;
using System.IO;

namespace TUploader.MainApp.Services
{
    public class SimpleDataStore
    {
        const string DataFile = "data.json";

        public void Save(object data)
        {
            string text = JsonConvert.SerializeObject(data);
            File.WriteAllText(DataFile, text);
        }

        public T Load<T>()
        {
            if (File.Exists(DataFile))
            {
                string text = File.ReadAllText(DataFile);
                return JsonConvert.DeserializeObject<T>(text);
            }

            return default;
        }
    }
}
