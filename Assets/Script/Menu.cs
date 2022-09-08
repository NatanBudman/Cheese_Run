using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject ButtonPanel;
    public GameObject levelPanel;
    public GameObject OptionPanel;
    public GameObject messege;

    private void Start()
    {
        levelPanel.SetActive(false);
        ButtonPanel.SetActive(true);
        OptionPanel.SetActive(false);

    }

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
