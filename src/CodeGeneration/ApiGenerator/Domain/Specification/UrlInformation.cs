﻿using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using HtmlParserSharp;

namespace ApiGenerator.Domain
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class UrlInformation
	{
		private IList<string> _paths;
		private IList<UrlPath> _exposedPaths;
		public IDictionary<string, QueryParameters> Params { get; set; }

		public string Path { get; set; }

		public IEnumerable<string> Paths
		{
			private get => _paths ?? Enumerable.Empty<string>();
			set => _paths = (value ?? Enumerable.Empty<string>()).ToList();
		}

		public IDictionary<string, UrlPart> Parts { get; set; }

		public IEnumerable<UrlPath> ExposedApiPaths
		{
			get
			{
				if (_exposedPaths != null) return _exposedPaths;

				_exposedPaths = Paths.Select(p => new UrlPath(p, Parts)).ToList();
				return _exposedPaths;
			}
		}

		public bool IsPartless => !ExposedApiParts.Any();

		public bool TryGetDocumentApiPath(out UrlPath path)
		{
			path = null;
			if (!IsDocumentApi) return false;

			var mostVerbosePath = _exposedPaths.OrderByDescending(p => p.Parts.Count()).First();
			path = new UrlPath(mostVerbosePath.Path, Parts, mostVerbosePath.Parts);
			return true;
		}


		public IEnumerable<UrlPart> ExposedApiParts => ExposedApiPaths.SelectMany(p => p.Parts).DistinctBy(p => p.Name).ToList();

		private static readonly string[] DocumentApiParts = { "index", "id" };
		public bool IsDocumentApi =>
			ExposedApiParts.Count() == DocumentApiParts.Length
			&& ExposedApiParts.All(p => DocumentApiParts.Contains(p.Name));
	}
}
