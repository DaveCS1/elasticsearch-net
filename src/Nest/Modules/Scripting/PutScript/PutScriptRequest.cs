using System.IO;
using Elasticsearch.Net;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public interface IPutScriptRequest : IRequest<PutScriptRequestParameters>
	{
		[JsonProperty("script")]
		string Script { get; set; }
		[JsonIgnore]
		string Id { get; set; }
		[JsonIgnore]
		string Lang { get; set; }
	}

	public partial class PutScriptRequest : RequestBase<PutScriptRequestParameters>, IPutScriptRequest
	{
		public string Lang { get; set; }
		public string Id { get; set; }
		public string Script { get; set; }
	}

	[DescriptorFor("ScriptPut")]
	public partial class PutScriptDescriptor : RequestDescriptorBase<PutScriptDescriptor, PutScriptRequestParameters>, IPutScriptRequest
	{
		IPutScriptRequest Self => this;
		string IPutScriptRequest.Script { get; set; }
		string IPutScriptRequest.Id { get; set; }
		string IPutScriptRequest.Lang { get; set; }

		public PutScriptDescriptor Id(string id)
		{
			id.ThrowIfNullOrEmpty("id");
			this.Self.Id = id;
			return this;
		}

		public PutScriptDescriptor Lang(ScriptLang lang)
		{
			this.Self.Lang = lang.GetStringValue();
			return this;
		}

		public PutScriptDescriptor Lang(string lang)
		{
			lang.ThrowIfNullOrEmpty("lang");
			this.Self.Lang = lang;
			return this;
		}

		public PutScriptDescriptor Script(string script)
		{
			this.Self.Script = script;
			return this;
		}
	}
}