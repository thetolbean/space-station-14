namespace Content.Server.power.PTL
{
    /// <summary>
    /// Stores power and then transfers it via bluespace to other stations.
    /// </summary>
    [RegisterComponent]
    public sealed partial class PtlComponent : Component
    {
        /// <summary>
        /// If the PTL is currently set to sell power.
        /// </summary>
        [ViewVariables]
        public bool Enabled = true;

        /// <summary>
        /// The amount of power (in watts) to draw when turned on
        /// </summary>
        [DataField("powerDraw")]
        [ViewVariables(VVAccess.ReadWrite)]
        public int PowerDraw = 1000;

        /// <summary>
        /// The amount of power the particle accelerator must be provided with relative to the expected power draw to function.
        /// </summary>
        [ViewVariables]
        public const float RequiredPowerRatio = 0.999f;

        /// <summary>
        /// The amount of time between
        /// </summary>
        [DataField("sellTime")]
        [ViewVariables(VVAccess.ReadWrite)]
        public TimeSpan SellTime = TimeSpan.FromSeconds(1.0);

        /// <summary>
        /// The time at which the PA last fired a wave of particles.
        /// </summary>
        [DataField("lastSell")]
        [ViewVariables(VVAccess.ReadWrite)]
        public TimeSpan LastSell;

        /// <summary>
        /// The time at which the PA will next fire a wave of particles.
        /// </summary>
        [DataField("nextSell")]
        [ViewVariables(VVAccess.ReadWrite)]
        public TimeSpan NextSell;
    }
}
