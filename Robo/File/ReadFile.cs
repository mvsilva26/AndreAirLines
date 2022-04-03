using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;


namespace File
{
    public class ReadFile
    {

     
        public static List<Voo>? ExtrairDados(string pathFile)
        {
            StreamReader r = new StreamReader(pathFile);
            string jsonString = r.ReadToEnd();
            var dados = JsonConvert.DeserializeObject<List<Voo>>(jsonString) as List<Voo>;

            return dados ?? null;
        }

       





    }
}
