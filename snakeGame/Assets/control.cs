using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class control : MonoBehaviour
{
  public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
public void ExitIngameToMenu()
    {
        SceneManager.LoadScene(0);
    }
  public void Exit()
    {
        Application.Quit();
    }
   public void PauseGame()
    {
        Time.timeScale = 0;
    }
   public void ResumeGame()
    {
        Time.timeScale = 0.25f;
    }
    public void HOME()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0.25f;
    }
    public void replay()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0.25f;
    }
}
