using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject endScreenPanel; 
    public AudioSource backgroundMusic;
    public TextMeshProUGUI statusText; 

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
        if (endScreenPanel != null) endScreenPanel.SetActive(false);
    }

    public void ToggleMusic()
    {
        if (backgroundMusic != null)
            backgroundMusic.mute = !backgroundMusic.mute;
    }

    public void ShowEndScreen(bool won)
    {
        if (endScreenPanel != null)
        {
            endScreenPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; 

            
            if (won)
            {
                statusText.text = "Congratulations!";
                statusText.color = Color.green; 
            }
            else
            {
                statusText.text = "GAME OVER :( ";
                statusText.color = Color.red; 
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}