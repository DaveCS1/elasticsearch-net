﻿namespace Nest
{
	[MapsApi("get_source.json")]
	public partial interface ISourceRequest { }

	public partial interface ISourceRequest<TDocument> where TDocument : class { }

	public partial class SourceRequest
	{
		private object AutoRouteDocument() => null;
	}

	public partial class SourceRequest<TDocument> where TDocument : class
	{
		private object AutoRouteDocument() => null;
	}

	public partial class SourceDescriptor<TDocument> where TDocument : class
	{
		private object AutoRouteDocument() => null;

		public SourceDescriptor<TDocument> ExecuteOnPrimary() => Preference("_primary");

		public SourceDescriptor<TDocument> ExecuteOnLocalShard() => Preference("_local");
	}
}
