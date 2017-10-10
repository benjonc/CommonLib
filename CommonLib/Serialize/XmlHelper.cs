using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CommonLib.Serialize
{
    class XmlHelper
    {
        /// <summary>
        /// 保存为xml,序列化
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        public void SaveXml(string path, object obj, string nameSpace = "")
        {
            if (!string.IsNullOrWhiteSpace(path) && obj != null)
            {
                Type type = obj.GetType();
                using (StreamWriter writer = new StreamWriter(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(type);
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", nameSpace); //not ot output the default namespace
                    xmlSerializer.Serialize(writer, obj, ns);
                }

            }
        }

        /// <summary>
        /// 读取xml，反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public T ReadXml<T>(Type type, string xml)
        {


            return default(T);
        }

        /// <summary>
        /// 根据xml自动生成类
        /// </summary>
        /// <param name="classPath"> 生成的类所在的路径 </param>
        /// <param name="xml"> xml的路径 </param>
        public void CreateClassByXml(string classPath, string xml)
        {

        }
    }
}
