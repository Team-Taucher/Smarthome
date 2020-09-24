using System.Collections.Generic;
using Gelp.SmartHome.Common.Data;

namespace Gelp.SmartHome.Communication.Web.Models
{
    public class DashboardModel
    {
        public User User { get; set; }
        
        public List<Device> Devices { get; set; }
    }
}