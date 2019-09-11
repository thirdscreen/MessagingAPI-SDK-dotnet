using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace com.telstra.messaging.Serialization
{
    internal class XmlEncodingSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return XmlReader.Create(new StringReader("<r>" + existingValue.ToString() + "</r>")).ReadElementString();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(new XText(value.ToString()).ToString());
        }
    }
}
