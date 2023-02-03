using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public enum Scenes
    {
      bootUp, //Reference for the starting credits scene
      title,
      waveOne,
      waveTwo,
      waveThree,
      waveBoss,
      gameOver
     }

    public void BeginGame()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.Instance.gameState = GameManager.GameStates.Play;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
        
    public void MainScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    { 
        Application.Quit();
    }

}