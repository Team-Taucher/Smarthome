namespace Gelp.SmartHome.Common.Data
{
    /// <summary>
    /// Contains all informations about a user
    /// </summary>
    public class User : BaseObject
    {
        /// <summary>
        /// Username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
    }
}
