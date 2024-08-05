using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [field: SerializeField]
    public GameObject DeathWindow { get; private set; }
    [field: SerializeField]
    public Button Restart { get; private set; }
    [field: SerializeField]
    public Button BackToMainMenu {get; private set;}

    private void Start()
    {
        Restart.onClick.AddListener(RestartGame);
        BackToMainMenu.onClick.AddListener(BackToMenu);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }
    public void EnableAndDisable(GameObject uiElement)
    {
        uiElement.SetActive(!uiElement.activeSelf);
    }
}
