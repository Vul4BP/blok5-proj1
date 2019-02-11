using Blok5_P1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Blok5_P1
{
    public class ListFromXml
    {
        private static ListFromXml _instance;
        private static object _syncLock = new object();

        public ListFromXml()
        {
            ReadFromXml();
        }
        public static ListFromXml getInstance()
        {
            lock (_syncLock)
            {
                if (_instance == null)
                {
                    _instance = new ListFromXml();
                }
            }
            return _instance;
        }
        public List<User> Users { get; set; } = new List<User>();

        public void SaveToXml()
        {
            String location = Config.XmlFile;
            try
            {
                using (var writer = new StreamWriter(location))
                {
                    var serializer = new XmlSerializer(typeof(List<User>));
                    serializer.Serialize(writer, Users);
                    writer.Flush();
                }
            }
            catch
            {
            }
        }

        public void ReadFromXml()
        {
            String location = Config.XmlFile;
            if (string.IsNullOrEmpty(location))
                return;
            try
            {
                using (var fs = new FileStream(location, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs, Encoding.Default))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                    Users = (List<User>)serializer.Deserialize(sr);
                }
            }
            catch
            {
            }
        }
    }
}
