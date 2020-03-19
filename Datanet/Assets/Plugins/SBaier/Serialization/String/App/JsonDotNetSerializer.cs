
using Newtonsoft.Json;

namespace SBaier.Serialization.String
{
	public class JsonDotNetSerializer : StringSerializer
	{
		public override TSerializable Deserialize<TSerializable>(string serialized)
		{
			if (string.IsNullOrEmpty(serialized))
				return default;
			return JsonConvert.DeserializeObject<TSerializable>(serialized);
		}

		public override string Serialize<TSerializable>(TSerializable serializable)
		{
			if (serializable == default)
				return string.Empty;
			return JsonConvert.SerializeObject(serializable);
		}
	}
}