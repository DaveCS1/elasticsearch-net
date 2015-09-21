﻿using System;
using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net;

namespace Nest
{
	public interface IScrollRequest : IRequest<ScrollRequestParameters>
	{
		string ScrollId { get; set; }
		TimeUnitExpression Scroll { get; set; }
	}
	
	//TODO complex old route update routine needs to be ported

	//internal static class ScrollPathInfo
	//{
	//	public static void Update(
	//		IScrollRequest request,
	//		IConnectionSettingsValues settings, 
	//		RouteValues pathInfo)
	//	{
	//		// force POST scrollId can be quite big
	//		pathInfo.HttpMethod = HttpMethod.POST;
	//		pathInfo.ScrollId = request.ScrollId;
	//		// force scroll id out of RequestParameters (potentially very large)
	//		request.RequestParameters.RemoveQueryString("scroll_id");
	//		request.RequestParameters.AddQueryString("scroll", request.Scroll);
	//	}
	//}

	public partial class ScrollRequest : RequestBase<ScrollRequestParameters>, IScrollRequest
	{
		public string ScrollId { get; set; }
		public TimeUnitExpression Scroll { get; set; }

		public ScrollRequest(string scrollId, TimeUnitExpression scrollTimeout)
		{
			this.ScrollId = scrollId;
			this.Scroll = scrollTimeout;
		}
	}

	public partial class ScrollDescriptor<T> : RequestDescriptorBase<ScrollDescriptor<T>, ScrollRequestParameters>, IScrollRequest,
		IHideObjectMembers
		where T : class
	{
		private IScrollRequest Self => this;

		string IScrollRequest.ScrollId { get; set; }
		TimeUnitExpression IScrollRequest.Scroll { get; set; }
		
		///<summary>Specify how long a consistent view of the index should be maintained for scrolled search</summary>
		public ScrollDescriptor<T> Scroll(TimeUnitExpression scroll)
		{
			Self.Scroll = scroll;
			return this;
		}
		
		///<summary>The scroll id used to continue/start the scrolled pagination</summary>
		public ScrollDescriptor<T> ScrollId(string scrollId)
		{
			Self.ScrollId = scrollId;
			return this;
		}
	}
}
