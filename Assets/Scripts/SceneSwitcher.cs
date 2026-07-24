using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher: MonoBehaviour
{
    public static void GoToMainMenu() => 
        SceneManager.LoadScene(sceneBuildIndex: 0);

    public void GoToGame() => 
        SceneManager.LoadScene(sceneBuildIndex: 1);

    public static void GoToWinScene() => 
        SceneManager.LoadScene(sceneBuildIndex: 2);

    public static void GoToNotWinScene() => 
        SceneManager.LoadScene(sceneBuildIndex: 3);

    public void Exit() => 
        Application.Quit();
}