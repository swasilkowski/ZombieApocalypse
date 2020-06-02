using Assets.Scripts.Settings;

namespace Assets.Scripts
{
    public class GameState
    {
        public int EnemiesKilled { get; set; }
        public int EnemiesAlive { get; set; }
        public bool IsFireStrikeAtCoolDown { get; set; }
        public float FireStrikeCoolDownTimer { get; set; }
        public bool IsIceBlastAtCoolDown { get; set; }
        public float IceBlastCoolDownTimer { get; set; }
        public float GameStartTime { get; set; }
        public bool GameOver { get; set; }

        public void StartFireStrikeCoolDownTimer()
        {
            this.IsFireStrikeAtCoolDown = true;
            this.FireStrikeCoolDownTimer = SettingsManager.GetInstance().FireStrikeCoolDownPeriod;
        }

        public void StartIceBlastCoolDownTimer()
        {
            this.IsIceBlastAtCoolDown = true;
            this.IceBlastCoolDownTimer = SettingsManager.GetInstance().IceBlastCoolDownPeriod;
        }

        public void ResetState()
        {
            this.EnemiesAlive = 0;
            this.EnemiesKilled = 0;
            this.IsFireStrikeAtCoolDown = false;
            this.IsIceBlastAtCoolDown = false;
            this.GameOver = false;
        }

        private static GameState instance;

        private GameState() 
        {
            this.ResetState();
        }

        public static GameState GetInstance()
        {
            if (GameState.instance == null)
            {
                GameState.instance = new GameState();
            }

            return GameState.instance;
        }
    }
}
