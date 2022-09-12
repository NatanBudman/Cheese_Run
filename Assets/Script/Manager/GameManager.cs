using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelCanvas Canvas;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Points _points;
    public int CheeseRecolected;

    private bool isVictory = false;
    private bool isPlayerLive = true;
    void Start()
    {
        PauseGame(false);
        _points = FindObjectOfType<Points>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (_playerController.gameObject.activeSelf == false) isPlayerLive = false;
        else isPlayerLive = true;
     
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame(true);
            Canvas.OptionsPanel.SetActive(true);
        }

        else if (Input.GetKey(KeyCode.Escape))
        {
            Canvas.OptionsPanel.SetActive(false);
            PauseGame(false);
        }

        VictoryConditions();

        LoseConditions();
    }

    public void PauseGame(bool IsPause)
    {
        if (IsPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void VictoryConditions()
    {
        var FirstStar = _points.CheeseNeed * 25 / 100;
        var SecondStar =_points.CheeseNeed * 50 / 100;
        var ThirdStar = _points.CheeseNeed * 75 / 100;
        
        if (CheeseRecolected >= FirstStar && FirstStar < SecondStar)
        {
            Canvas.StarsEarned(1);
        }
        if (CheeseRecolected >= SecondStar && SecondStar < ThirdStar)
        {
            Canvas.StarsEarned(2);
        }
        if (CheeseRecolected >= ThirdStar)
        {
            Canvas.StarsEarned(3);
        }

        if (CheeseRecolected >= FirstStar && !isPlayerLive || CheeseRecolected == _points.CheeseNeed)
        {
            Victory();
            isVictory = true;
        }
    }

    private void Victory()
    {
        Canvas.VictoryPanel.SetActive(true);
    }

    public bool VictoryLevel()
    {
        return isVictory;
    }

    public void LoseConditions()
    {
        if (_playerController.gameObject.activeSelf == false && CheeseRecolected <= _points.CheeseNeed * 25 / 100) Lose();
    }

    private void Lose()
    {
        Canvas.LosePanel.SetActive(true); 
    }

    
}
