using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    //UI Elements
    bool isPaused = false;
    bool isOptions = true;

    [SerializeField] GameObject pausePanel;

    //Custom delegates 
    public delegate void OnScoreUpdate();
    public static OnScoreUpdate onScoreUpdate;
    public delegate void OnLifeUpdate();
    public static OnLifeUpdate onLifeUpdate;

    void Awake()
    {
        onScoreUpdate = ScoreSystem;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        pausePanel.SetActive(isPaused);

        Cursor.visible = isPaused;

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0; //Set a timescale to 0 and pause any behaviour that uses Time to calculate itself
            GameManager.Instance.gameState = GameManager.GameStates.Pause;
        }

        else if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            GameManager.Instance.gameState = GameManager.GameStates.Play;
        }
    }

    public void SetOptions (bool value)
    {
        isOptions = value;
    }
    public void LifeSystemTracker()
    {
    
    }

    public void ScoreSystem()
    { 
    
    }

}
