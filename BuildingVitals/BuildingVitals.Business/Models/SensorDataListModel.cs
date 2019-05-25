using System;
using System.Collections.Generic;

namespace BuildingVitals.BusinessContracts.Models
{
    public class SensorDataListModel
    {
        public Guid SensorId { get; set; }

        public List<DateTime> Dates { get; set; }

        public List<double> DataList { get; set; }
    }
}
