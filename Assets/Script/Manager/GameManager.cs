using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Scripts_Zone

     [SerializeField] private LevelCanvas Canvas;
     [SerializeField] private PlayerController _playerController;
     [SerializeField] private Points _points;

    #endregion

    #region Time

      public float GameTime;
      private float CurrentGammeTime;

    #endregion

    #region Cheese

    public int CheeseRecolected;

    #endregion

    #region GamePlay

    public BackgroundScroller[] BackgroundScrollers;
        
    public bool isFinishGame = false;
    private bool isVictory = false;
    private bool isPlayerLive = true;

    #endregion

    
 
    void Start()
    {
        
        PauseGame(false);

        CurrentGammeTime = GameTime;
        Seconds = CurrentGammeTime;
        
        _points = FindObjectOfType<Points>();
        
        _playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        // Verfica si esta vivo el player
        if (_playerController.gameObject.activeSelf == false) isPlayerLive = false;
        else isPlayerLive = true;

      
        
        // Pausa
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

        //  Level Status
        if (!isPlayerLive || CurrentGammeTime < 1 || CheeseRecolected >= _points.CheeseNeed)
        {
            isFinishGame = true;
        }

       

        if (isFinishGame)
        {
            VictoryConditions();
            
            LoseConditions();
        }
        else
        {
            CanvasGameTime();
        }

    }

    #region Game

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
    
        private void LoseConditions()
        {
            if (_playerController.gameObject.activeSelf == false && CheeseRecolected <= _points.CheeseNeed * 25 / 100)
            {
                 Lose();
            }
        }
    
        private void Lose()
        {
            Canvas.LosePanel.SetActive(true); 
            _playerController.Death();
        }
        
        float Minute;
        float Seconds;
        private void CanvasGameTime()
        {
            // Game Time
            if (!isFinishGame)
            {
                CurrentGammeTime -= Time.deltaTime;
                Seconds -= Time.deltaTime;
            }
            
            if (Seconds > 60 )
            {
                Seconds -= 60;
                Minute += 1; 
            }

            if (Seconds < 1 && Minute > 0)
            {
                Minute -= 1; 
                Seconds += 60;
            }

            int Minutos = (int)Minute;
            int Segundos = (int)Seconds;
            Canvas.gameTimeText.text = "" + Minutos+ " : " + Segundos;

        }

    
    #endregion
   

    
}
