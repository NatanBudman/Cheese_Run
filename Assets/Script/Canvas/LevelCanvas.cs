using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public GameObject LosePanel;
    public GameObject VictoryPanel;
    public GameObject[] Stars;
    public GameObject OptionsPanel;

    private int LevelStars;

    [SerializeField] private string NextLevelSceneName; 
  
    // Update is called once per frame
    void Update()
    {
        if (LevelStars == 1 )
        {
            if (_gameManager.VictoryLevel())  GetStars(1);
        }
        if (LevelStars == 2 )
        {
            if (_gameManager.VictoryLevel())  GetStars(2);
        }
        if (LevelStars == 3 )
        {
            if (_gameManager.VictoryLevel())  GetStars(3);
        }
    }

    private void GetStars(int StarsEearned)
    {
        for (int i = 0; i < StarsEearned; i++)
        {
            Stars[i].SetActive(true);
            if (Stars[i].transform.localScale.x <= 0.7f || Stars[i].transform.localScale.y <= 0.7f)
            {
                Debug.Log(i);
                   Stars[i].transform.localScale 
                                = new Vector2((Stars[i].transform.localScale.x + 0.3f * Time.deltaTime),
                                    (Stars[i].transform.localScale.y + 0.3f * Time.deltaTime));
                  
            }
           
        }
    }
    public void StarsEarned(int amountStars)
    { 
        LevelStars = amountStars;
    }

    public void ResetLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LeaveToMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void NextLevel()
    {
        LevelLoad.LevelLoading(NextLevelSceneName);
    }

    public void DisablePuasePanel()
    {
        _gameManager.PauseGame(false);
        OptionsPanel.SetActive(false);
    }
}
