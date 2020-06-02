using Assets.Scripts;
using Assets.Scripts.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public ButtonType buttonType;

    public void HandleClick()
    {
        switch(buttonType)
        {
            case ButtonType.ExitGame:
                Application.Quit();
                break;
            case ButtonType.EasyLevel:
                SettingsManager.GetInstance().DifficultyLevel = DifficultyLevel.Easy;
                SceneManager.LoadScene("GameScene");
                break;
            case ButtonType.MediumLevel:
                SettingsManager.GetInstance().DifficultyLevel = DifficultyLevel.Medium;
                SceneManager.LoadScene("GameScene");
                break;
            case ButtonType.HardLevel:
                SettingsManager.GetInstance().DifficultyLevel = DifficultyLevel.Hard;
                SceneManager.LoadScene("GameScene");
                break;
            case ButtonType.ReturnToMainMenu:
                GameState.GetInstance().ResetState();
                SceneManager.LoadScene("MainMenuScene");
                break;
        }
    }
}
