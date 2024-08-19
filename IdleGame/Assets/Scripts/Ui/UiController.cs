using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController Instance;

    [field: SerializeField]
    public GameObject DeathWindow { get; private set; }
    [field: SerializeField]
    public Button Restart { get; private set; }
    [field: SerializeField]
    public Button BackToMainMenu {get; private set;}

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

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
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }

    public void EnableDeathPanel()
    {
        DeathWindow.SetActive(true);
    }

    public void EnableAndDisable(GameObject uiElement)
    {
        uiElement.SetActive(!uiElement.activeSelf);
    }
}
