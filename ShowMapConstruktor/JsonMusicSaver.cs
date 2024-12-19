using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace ShowMapConstruktor
{
    internal class JsonMusicSaver : ISaveList<List<CMusicShow>>
    {
        private readonly JsonSerializerOptions _options;

        public JsonMusicSaver()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new MusicShowConvertor() }
            };
        }

        public List<CMusicShow> Load(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                return JsonSerializer.Deserialize<List<CMusicShow>>(json, _options) ?? new List<CMusicShow>();
            }

            return new List<CMusicShow>();
        }

        public void Save(List<CMusicShow> data, string path)
        {
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(path, json);
        }
    }
}

