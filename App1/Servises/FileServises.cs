using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Servises
{
    class FileServises
    {
        private readonly string PATH;

        public FileServises(string path)
        {
            PATH = path;
        }
        public BindingList<Model> loadData()
        {
            var fileExists = File.Exists(PATH);

            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Model>();
            }

            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Model>>(fileText);
            }
        }

        public void saveData(object _ToDoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_ToDoDataList);
                writer.Write(output);
            }
        }
    }
}
