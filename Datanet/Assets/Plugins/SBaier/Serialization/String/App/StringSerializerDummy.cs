
namespace SBaier.Serialization.String
{
	public class StringSerializerDummy : StringSerializer
	{
		public override TSerializable Deserialize<TSerializable>(string serialized)
		{
			return default;
		}

		public override string Serialize<TSerializable>(TSerializable serializable)
		{
			return serializable.ToString();
		}
	}
}