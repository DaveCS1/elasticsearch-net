﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Elasticsearch.Net;

namespace Nest
{
	[InterfaceDataContract]
	[ReadAs(typeof(HourlySchedule))]
	public interface IHourlySchedule : ISchedule
	{
		[DataMember(Name = "minute")]
		IEnumerable<int> Minute { get; set; }
	}

	public class HourlySchedule : ScheduleBase, IHourlySchedule
	{
		public IEnumerable<int> Minute { get; set; }

		internal override void WrapInContainer(IScheduleContainer container) => container.Hourly = this;
	}

	public class HourlyScheduleDescriptor : DescriptorBase<HourlyScheduleDescriptor, IHourlySchedule>, IHourlySchedule
	{
		IEnumerable<int> IHourlySchedule.Minute { get; set; }

		public HourlyScheduleDescriptor Minute(params int[] minutes) => Assign(minutes, (a, v) => a.Minute = v);

		public HourlyScheduleDescriptor Minute(IEnumerable<int> minutes) => Assign(minutes, (a, v) => a.Minute = v);
	}
}
