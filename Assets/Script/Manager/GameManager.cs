using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Points _points;
    public int CheeseRecolected;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _points = FindObjectOfType<Points>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void VictoryConditions()
    {
        if (_points.CheeseNeed >= CheeseRecolected - CheeseRecolected * 25 / 100)
        {
            
        }
        if (_points.CheeseNeed >= CheeseRecolected - CheeseRecolected * 50 / 100)
        {
            
        }
        if (_points.CheeseNeed >= CheeseRecolected - CheeseRecolected * 75 / 100)
        {
            
        }
    }

    public void LoseConditions()
    {
        if (_points.CheeseNeed <= CheeseRecolected - CheeseRecolected * 25 / 100) Lose();

        if (_playerController.gameObject.activeSelf == false) Lose();
    }

    private void Lose()
    {
        
    }

}
