using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [Space]
    [Header("Game Status Panels")]
    [Space]
    public GameObject LosePanel;
    public GameObject VictoryPanel;
    public GameObject OptionsPanel;
    
    
    [Space]
    [Header("Conditions")]
    [Space]
    [SerializeField] private int LevelStars;
    public GameObject[] Stars;
    public Image BarStars;
    public Text gameTimeText;
    
    [Space]
    [Header("Others")]
    [Space]

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
        // "Activate" Stars 
        for (int i = 0; i < StarsEearned; i++)
        {
            Stars[i].SetActive(true);
            if (Stars[i].transform.localScale.x <= 0.7f || Stars[i].transform.localScale.y <= 0.7f)
            {
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
