//using System;
//using System.Xml.Serialization;
//using System.Collections.Generic;
//namespace tema1
//{
//    [XmlRoot(ElementName = "cuvant")]
//    public class Cuvant
//    {
//        [XmlElement(ElementName = "nume")]
//        public string Nume { get; set; }
//        [XmlElement(ElementName = "descriere")]
//        public string Descriere { get; set; }
//        [XmlElement(ElementName = "categorie")]
//        public string Categorie { get; set; }
//        [XmlElement(ElementName = "imagine")]
//        public string Imagine { get; set; }
//    }
//}


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace tema1
{
    public partial class Cuvant
    {
        [JsonProperty("denumire")]
        public string Denumire { get; set; }

        [JsonProperty("descriere")]
        public string Descriere { get; set; }

        [JsonProperty("categorie")]
        public string Categorie { get; set; }

        [JsonProperty("imagine")]
        public string Imagine { get; set; }
    }

    public partial class Cuvant
    {
        public static Cuvant[] FromJson(string json) => JsonConvert.DeserializeObject<Cuvant[]>(json, tema1.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Cuvant[] self) => JsonConvert.SerializeObject(self, tema1.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}