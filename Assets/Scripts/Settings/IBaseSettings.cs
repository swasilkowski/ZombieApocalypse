namespace Assets.Scripts.Settings
{
    /// <summary>
    /// Interface for basic settings, not depending on difficulty level
    /// </summary>
    interface IBaseSettings
    {
        /// <summary>
        /// Radius in Unity units around player in which enemies are spawned
        /// </summary>
        float EnemySpawnRadius { get; }

        /// <summary>
        /// Base value of enemy's HP
        /// </summary>
        int EnemyHp { get; }

        /// <summary>
        /// Amount of HP player looses when enemy explodes from collision between them
        /// </summary>
        int EnemyDamage { get; }

        /// <summary>
        /// Speed of enemy in Unity units per second
        /// </summary>
        float EnemySpeed { get; }

        /// <summary>
        /// Amount of HP enemy looses when enemy it gets hit by bullet
        /// </summary>
        int BulletDamage { get; }

        /// <summary>
        /// Speed of bullet in Unity units per second
        /// </summary>
        float BulletSpeed { get; }

        /// <summary>
        /// Amount of HP enemy looses when enemy it gets hit by fire strike spell
        /// </summary>
        int FireStrikeDamage { get; }

        /// <summary>
        /// Time in seconds fire strike spell needs to cool down between two casts
        /// </summary>
        float FireStrikeCoolDownPeriod { get; }

        /// <summary>
        /// Speed of fire strike spell in Unity units per second
        /// </summary>
        float FireStrikeSpeed { get; }

        /// <summary>
        /// Slow down factor of enemy affected by ice blast spell
        /// </summary>
        float IceBlastSlowDownFactor { get; }

        /// <summary>
        /// Ice blast spell effect time duriation in seconds
        /// </summary>
        float IceBlastSlowDownPeriod { get; }

        /// <summary>
        /// Time in seconds ice blast spell needs to cool down between two casts
        /// </summary>
        float IceBlastCoolDownPeriod { get; }

        /// <summary>
        /// Speed of ice blast spell in Unity units per second
        /// </summary>
        float IceBlastSpeed { get; }
    }
}
