namespace Assets.Scripts.Settings
{
    /// <summary>
    /// Singleton class containing game settings
    /// </summary>
    public class SettingsManager : BaseSettings, IDifficultyLevelSettings
    {
        private static SettingsManager instance;
        private readonly DifficultyLevelSettings easySettings;
        private readonly DifficultyLevelSettings mediumSettings;
        private readonly DifficultyLevelSettings hardSettings;

        /// <summary>
        /// Gets or sets difficulty level of game
        /// </summary>
        public DifficultyLevel DifficultyLevel { get; set; }

        private DifficultyLevelSettings DifficultyLevelSettings 
        { 
            get
            {
                switch(this.DifficultyLevel)
                {
                    case DifficultyLevel.Easy:
                        return this.easySettings;
                    case DifficultyLevel.Medium:
                        return this.mediumSettings;
                    case DifficultyLevel.Hard:
                        return this.hardSettings;
                    default:
                        return null;
                }
            } 
        }

        public int EnemiesSpawningCount => this.DifficultyLevelSettings.EnemiesSpawningCount;

        public float EnemiesSpawningInterval => this.DifficultyLevelSettings.EnemiesSpawningInterval;

        public int PlayerHp => this.DifficultyLevelSettings.PlayerHp;

        private SettingsManager()
        {

            BulletDamage = 75;
            BulletSpeed = 40f;
            IceBlastCoolDownPeriod = 0.8f;
            IceBlastSlowDownFactor = 0.5f;
            IceBlastSlowDownPeriod = 5f;
            IceBlastSpeed = 10f;
            EnemyDamage = 50;
            EnemyHp = 100;
            EnemySpawnRadius = 25;
            EnemySpeed = 0.3f;
            FireStrikeCoolDownPeriod = 0.4f;
            FireStrikeDamage = 60;
            FireStrikeSpeed = 15;
            

            this.easySettings = new DifficultyLevelSettings()
            {
                EnemiesSpawningCount = 3,
                EnemiesSpawningInterval = 0.2f,
                PlayerHp = 50000
            };

            this.mediumSettings = new DifficultyLevelSettings()
            {
                EnemiesSpawningCount = 6,
                EnemiesSpawningInterval = 0.1f,
                PlayerHp = 40000
            };

            this.hardSettings = new DifficultyLevelSettings()
            {
                EnemiesSpawningCount = 8,
                EnemiesSpawningInterval = 0.1f,
                PlayerHp = 30000
            };
        }

        public static SettingsManager GetInstance()
        {
            if (SettingsManager.instance == null)
            {
                SettingsManager.instance = new SettingsManager();
            }

            return SettingsManager.instance;
        }
    }
}
