using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gamePanel;

    void Start()
    {
        ShowMenu();
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void ShowGame()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}