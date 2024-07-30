using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TankTap.Stations.Domain.Commons
{
    internal class ValidationMessages
    {
        public static string NotNullOrEmpty(string parameterName) => $"{parameterName} cannot be null or empty.";
        public static string NotNull(string parameterName) => $"{parameterName} cannot be null.";
    }
}
