using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject ButtonPanel;
    public GameObject levelPanel;
    public GameObject OptionPanel;
    public GameObject messege;
    public GameObject TitleGamme;

    public Text MessegeInfo;
    private void Start()
    {
        levelPanel.SetActive(false);
        ButtonPanel.SetActive(true);
        OptionPanel.SetActive(false);

    }

    private void Update()
    {
        
        /// Messege Info \\\
        if (ButtonPanel.activeSelf == true)
        {       
            TitleGamme.SetActive(true); 
            MessegeInfo.text = "El icono de play es facil de reconocer";
        }
        else TitleGamme.SetActive(false);

        if (levelPanel.activeSelf == true) MessegeInfo.text = "A la hora de elegir niveles siempre tomamos encuenta el orden numérico";
        if (OptionPanel.activeSelf == true) MessegeInfo.text = "Ajustar es mas para el sonido y los gráficos";

      
        
    }

    /// Panels Activation \\\
    public void StarButton()
    {
        levelPanel.SetActive(true);
        ButtonPanel.SetActive(false);
    }

    public void OptionButton()
    {
        ButtonPanel.SetActive(false);
        OptionPanel.SetActive(true);
        
    }

    public void InfoButton()
    {
        if (messege.activeSelf)
        {
            messege.SetActive(false);
        }
        else
        {
            messege.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void returnButton()
    {
        ButtonPanel.SetActive(true);
        levelPanel.SetActive(false);
        OptionPanel.SetActive(false);
    }
}
