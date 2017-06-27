using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XmlOper
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\XMLFile1.xml";
            string Key = "";
            string Partner = "";
            string Seller_email = "";
            string Return_url = "";
            string Notify_url = "";
            string PublicKey = @"";
            if (File.Exists(xmlPath))
            {
                string xml = File.ReadAllText(xmlPath);
                var config = DeserializeXml<AlipayConfigModel>(xml);
                if (config != null)
                {
                    Key = config.Key;
                    Partner = config.Pid;
                    Seller_email = config.SellerEmail;
                    Return_url = config.ReturnUrl;
                    Notify_url = config.WapNotifyUrl;
                    PublicKey = config.AlipayPublicKey;
                }

                Console.WriteLine(string.Format("Key:{0}\r\nPartner:{1}\r\nSeller_email:{2}\r\nReturn_url:{3}\r\nNotify_url:{4}\r\nPublicKey:{5}", Key, Partner, Seller_email, Return_url, Notify_url, PublicKey));
            }

            Console.ReadKey();
        }

        #region xml序列化反序列化
        public static T DeserializeXml<T>(string xmlString) where T : class
        {
            try
            {
                if (string.IsNullOrEmpty(xmlString))
                    return null;
                using (StringReader sr = new StringReader(xmlString))
                {
                    System.Xml.Serialization.XmlSerializer xmldes =
                        new System.Xml.Serialization.XmlSerializer(typeof(T));
                    var procedureXmlObj = xmldes.Deserialize(sr);
                    if (procedureXmlObj != null)
                        return (T)procedureXmlObj;
                }
                return null;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static string SerializeXml(Object xmlObj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(xmlObj.GetType());
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, new UTF8Encoding(false));
                xmlSerializer.Serialize(xmlTextWriter, xmlObj, namespaces);
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
                UTF8Encoding uTF8Encoding = new UTF8Encoding(false, true);
                return uTF8Encoding.GetString(memoryStream.ToArray());
            }
        }
        #endregion
    }

    [XmlRoot("alipay")]
    public class AlipayConfigModel
    {
        [XmlElement("appId")]
        public string AppId { get; set; }

        [XmlElement("alipay_public_key")]
        public string AlipayPublicKey { get; set; }

        [XmlElement("merchant_private_key")]
        public string MerchantPrivateKey { get; set; }

        [XmlElement("merchant_public_key")]
        public string MerchantPublicKey { get; set; }

        [XmlElement("pid")]
        public string Pid { get; set; }

        [XmlElement("seller_email")]
        public string SellerEmail { get; set; }

        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("notify_url")]
        public string NotifyUrl { get; set; }
        [XmlElement("wapnotify_url")]
        public string WapNotifyUrl { get; set; }

        [XmlElement("return_url")]
        public string ReturnUrl { get; set; }

        [XmlElement("refund_notify_url")]
        public string RefundNotifyUrl { get; set; }

        [XmlElement("refund_maintain_notify_url")]
        public string RefundMaintainNotifyUrl { get; set; }


    }
}
