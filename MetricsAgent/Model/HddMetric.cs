﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Model
{
    public class HddMetric
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}
