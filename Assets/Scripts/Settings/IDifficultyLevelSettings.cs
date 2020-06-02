namespace Assets.Scripts.Settings
{
    interface IDifficultyLevelSettings
    {
        /// <summary>
        /// Number of enemies spawning each spawn cycle
        /// </summary>
        int EnemiesSpawningCount { get; }

        /// <summary>
        /// Time interval in seconds between each spawn cycle
        /// </summary>
        float EnemiesSpawningInterval { get; }

        /// <summary>
        /// Base value of player's HP
        /// </summary>
        int PlayerHp { get; }
    }
}
