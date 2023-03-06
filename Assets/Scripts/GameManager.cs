using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   static GameManager instance;

    //Player values

    public static int playerHealth;
    public static Vector3 playerPosition = Vector3.zero;

    //GameStates functionality
    public enum GameState
    { 
        None,
        Play,
        Pause,
    }
    public GameState gameState = GameState.Play;

    public static GameManager Instance
    {
        get { return instance; } // Access to the GameManager publicly
        private set { instance = value; } // Only allow modification of the GameManager object privately
    }

    private void Start()
    {
        CheckGameManager();
    }

    private void Update()
    {
        
    }

    void CheckGameManager()
    {
        //1. To check if there is already an existing GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else //2. If a game object for the GameManager exists, we destroy the new game object that is trying to create itself
        {
            Destroy(this.gameObject);
        }
    }

    

}



