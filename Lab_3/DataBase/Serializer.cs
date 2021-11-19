using System.IO;
using System.Xml.Serialization;

namespace Lab_3.DataBase
{
    static class Serializer
    {
        // можно ли обойтись методом с ref, в случае десериализации свойства
        public static void Deserialize<T>(string path, ref T list)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            var s = new XmlSerializer(typeof(T));
            list = (T)s.Deserialize(fs);
        }
        public static T Deserialize<T>(string path, T list)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            var s = new XmlSerializer(typeof(T));
            return list = (T)s.Deserialize(fs);
        }

        // можно ли сериализовать TaxiFromXml в Taxi автоматически
        public static void Serialize<T>(string path, T list)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            var s = new XmlSerializer(typeof(T));
            s.Serialize(fs, list);
        }
    }
}
