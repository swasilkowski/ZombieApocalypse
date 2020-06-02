namespace Assets.Scripts.Settings
{
    /// <summary>
    /// Abstract class for basic settings, not depending on difficulty level
    /// </summary>
    public abstract class BaseSettings : IBaseSettings
    {
        public float EnemySpawnRadius { get; set; }
        public int EnemyHp { get; set; }
        public int EnemyDamage { get; set; }
        public float EnemySpeed { get; set; }
        public int BulletDamage { get; set; }
        public float BulletSpeed { get; set; }
        public int FireStrikeDamage { get; set; }
        public float FireStrikeCoolDownPeriod { get; set; }
        public float FireStrikeSpeed { get; set; }
        public float IceBlastSlowDownFactor { get; set; }
        public float IceBlastSlowDownPeriod { get; set; }
        public float IceBlastCoolDownPeriod { get; set; }
        public float IceBlastSpeed { get; set; }
    }
}
