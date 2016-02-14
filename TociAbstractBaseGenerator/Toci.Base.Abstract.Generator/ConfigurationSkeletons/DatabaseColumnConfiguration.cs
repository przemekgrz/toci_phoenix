﻿using Toci.Base.Abstract.Generator.Interfaces.ConfigurationSkeletons;

namespace Toci.Base.Abstract.Generator.ConfigurationSkeletons
{
    public class DatabaseColumnConfiguration: IDatabaseColumnConfiguration
    {
        public string Kind { get; set; }

        public object Value { get; set; }

        public string Constraints { get; set; }
    }
}