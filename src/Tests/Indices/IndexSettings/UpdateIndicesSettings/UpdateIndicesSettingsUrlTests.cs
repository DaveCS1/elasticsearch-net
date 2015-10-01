﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Tests.Framework;
using Tests.Framework.MockData;
using static Nest.Indices;
using static Nest.Types;
using static Tests.Framework.UrlTester;

namespace Tests.Modules.Indices.IndexSettings.UpdateIndicesSettings
{
	public class UpdateIndicesSettingsUrlTests
	{
		[U] public async Task Urls()
		{
			var index = "index1,index2";
			Nest.Indices indices = index;
			await PUT($"/{index}/_settings")
				.Fluent(c => c.UpdateIndexSettings(indices, s=>s))
				.Request(c => c.UpdateIndexSettings(new UpdateIndexSettingsRequest(index)))
				.FluentAsync(c => c.UpdateIndexSettingsAsync(indices, s=>s))
				.RequestAsync(c => c.UpdateIndexSettingsAsync(new UpdateIndexSettingsRequest(index)))
				;
			await PUT($"/_settings")
				.Fluent(c => c.UpdateIndexSettings(AllIndices, s=>s))
				.Request(c => c.UpdateIndexSettings(new UpdateIndexSettingsRequest()))
				.FluentAsync(c => c.UpdateIndexSettingsAsync(AllIndices, s=>s))
				.RequestAsync(c => c.UpdateIndexSettingsAsync(new UpdateIndexSettingsRequest()))
				;
		}
	}
}
