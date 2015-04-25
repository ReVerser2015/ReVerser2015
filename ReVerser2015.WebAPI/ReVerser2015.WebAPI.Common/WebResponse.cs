using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using dr = System.Drawing;
using net = System.Net;
using io = System.IO;
using json = Newtonsoft.Json;
using xml = System.Xml;

namespace ReVerser2015.WebAPI.Common
{
    public class WebResponse
    {
        private byte[] bytes;

        private net.WebResponse mResponse;

        private io.Stream mRespStream;

        public WebResponse(net.WebResponse response)
        {
            mResponse = response;
        }

        public io.Stream Stream
        {
            get
            {
                if (mRespStream == null)
                {
                    mRespStream = mResponse.GetResponseStream();
                }
                return mRespStream;
            }
        }

        public byte[] ToBytesArray()
        {
            if (bytes == null)
            {
                var bytesList = new List<byte>();

                int byt;
                while ((byt = this.Stream.ReadByte()) != -1)
                {
                    bytesList.Add((byte)byt);
                }

                bytes = bytesList.ToArray();
            }

            return bytes;
        }

        public string ToString(Encoding encoding)
        {
            return encoding.GetString(this.ToBytesArray());
        }

        public dr.Image ToImage(Encoding encoding)
        {
            using (var ms = new io.MemoryStream(this.bytes))
            {
                return dr.Image.FromStream(ms);
            }
        }

        public json.Linq.JObject ToJSON(Encoding encoding)
        {
            return json.Linq.JObject.Parse(this.ToString(encoding));
        }

        public xml.XmlDocument ToXML(Encoding encoding)
        {
            var xmlDoc = new xml.XmlDocument();
            xmlDoc.LoadXml(this.ToString(encoding));
            return xmlDoc;
        }
    }
}
