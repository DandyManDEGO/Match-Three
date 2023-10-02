using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
    
{
    [SerializeField] private GameObject pause;
    private bool isPaused = false;
    public void Ok()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Bonus()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void EixtToMenu(int sceneIndex)
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void Resum()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f; 
        isPaused = true;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
