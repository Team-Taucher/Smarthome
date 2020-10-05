using Gelp.SmartHome.Common.Data;

namespace Gelp.SmartHome.Communication.Database
{
    /// <summary>
    /// Repository for <see cref="Device"/>
    /// </summary>
    public class DeviceRepository : BaseRepository<Device>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DeviceRepository() : base("Device")
        {
        }
    }
}
