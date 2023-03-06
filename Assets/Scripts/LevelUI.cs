using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    //UI Elements
    bool isPaused = false;
    bool isOptions = true;
    
    //Custom delegates 
    public delegate void OnScoreUpdate();
    public static OnScoreUpdate onScoreUpdate;
    public delegate void OnLifeUpdate();
    public static OnLifeUpdate onLifeUpdate;

    [SerializeField] GameObject pausePanel;

    [SerializeField] Slider playerHealthSlider;

    [SerializeField] TMP_Text scoreText;
    void Awake()
    {
        onScoreUpdate = ScoreSystem;

    }

    // Start is called before the first frame update
    void Start()
    {
        onScoreUpdate = ScoreSystem;
        onLifeUpdate = LifeSystemTracker;
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
            GameManager.Instance.gameState = GameManager.GameState.Pause;
        }

        else if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            GameManager.Instance.gameState = GameManager.GameState.Play;
        }
    }

    public void SetOptions (bool value)
    {
        isOptions = value;
    }
    public void LifeSystemTracker()
    {
        if (GameManager.playerHealth > 0)playerHealthSlider.value = GameManager.playerHealth;
        
    }
    public void ScoreSystem()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore;
    }

}
