using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Text aliveEnemiesText;
    public Text killedEnemiesText;
    public Text fireStrikeText;
    public Text iceBlastText;
    public Text gameTimeText;
    public GameObject gameOverPopUp;

    private GameState gameState;
    private bool isGameOverScreenShown = false;

    private void Start()
    {
        gameState = GameState.GetInstance();
    }

    private void Update()
    {
        // alive enemies and killed enemies counters update
        this.aliveEnemiesText.text = $"Alive enemies: {this.gameState.EnemiesAlive}";
        this.killedEnemiesText.text = $"Killed enemies: {this.gameState.EnemiesKilled}";

        //fire strike icon update
        if (this.gameState.IsFireStrikeAtCoolDown)
        {
            this.gameState.FireStrikeCoolDownTimer -= Time.deltaTime;
            if (this.gameState.FireStrikeCoolDownTimer > 0)
            {
                this.fireStrikeText.text = $"{this.gameState.FireStrikeCoolDownTimer:N1}s";
            }
            else
            {
                this.gameState.FireStrikeCoolDownTimer = 0;
                this.gameState.IsFireStrikeAtCoolDown = false;
                this.fireStrikeText.text = "";
            }
        }

        //ice blast icon update
        if (this.gameState.IsIceBlastAtCoolDown)
        {
            this.gameState.IceBlastCoolDownTimer -= Time.deltaTime;
            if (this.gameState.IceBlastCoolDownTimer > 0)
            {
                this.iceBlastText.text = $"{this.gameState.IceBlastCoolDownTimer:N1}s";
            }
            else
            {
                this.gameState.IceBlastCoolDownTimer = 0;
                this.gameState.IsIceBlastAtCoolDown = false;
                this.iceBlastText.text = "";
            }
        }

        //game over popup update
        if (this.gameState.GameOver && !this.isGameOverScreenShown)
        {
            this.gameOverPopUp.SetActive(true);
            this.gameTimeText.text = $"You were alive for {Time.time - this.gameState.GameStartTime:N0} seconds";
            this.isGameOverScreenShown = true;
        }
    }
}
