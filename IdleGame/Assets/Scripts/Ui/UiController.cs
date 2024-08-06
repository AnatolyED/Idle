using System;
using UnityEngine;
using UnityEngine.Events;
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

    private void OnEnable()
    {
        Restart.onClick.AddListener(RestartGame);
        BackToMainMenu.onClick.AddListener(BackToMenu);
        Player.onDeath += EnableDeathPanel;
    }

    private void OnDisable()
    {
        Restart.onClick.RemoveListener(RestartGame);
        BackToMainMenu.onClick.RemoveListener(BackToMenu);
        Player.onDeath -= EnableDeathPanel;
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

    private void EnableDeathPanel()
    {
        DeathWindow.SetActive(!DeathWindow.activeSelf);
    }

    public void EnableAndDisable(GameObject uiElement)
    {
        uiElement.SetActive(!uiElement.activeSelf);
    }
}
