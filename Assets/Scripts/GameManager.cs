using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private UIManager _uiManager;

    private bool _gameComplete;
    // Start is called before the first frame update
    void Start()
    {
        _gameComplete = false;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
            Debug.LogError("UI Manager was not initialised in GameManager class");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (_gameComplete)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void GameCompleteSequence(int coinCount, int deathCount)
    {
        Time.timeScale = 0;
        _uiManager.GameCompleteUIUpdate(coinCount, deathCount);
        _gameComplete = true;
    }
}
