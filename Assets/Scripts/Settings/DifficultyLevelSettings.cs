namespace Assets.Scripts.Settings
{
    public class DifficultyLevelSettings : IDifficultyLevelSettings
    {
        public int EnemiesSpawningCount { get; set; }
        public float EnemiesSpawningInterval { get; set; }
        public int PlayerHp { get; set; }
    }
}
