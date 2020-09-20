namespace Gelp.SmartHome.Common.Data
{
    /// <summary>
    /// Contains all informations about a user
    /// </summary>
    public class Device : BaseObject
    {
        /// <summary>
        /// Name of the device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Port of the device
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Indicates whether the device is activated or not
        /// </summary>
        public bool IsActivated { get; set; }
    }
}
