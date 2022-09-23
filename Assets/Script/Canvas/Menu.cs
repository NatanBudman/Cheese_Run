using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject LoginPanel;
    public GameObject PlayerDataPanel;
    public GameObject ButtonPanel;
    public GameObject levelPanel;
    public GameObject OptionPanel;
    public GameObject messege;
    public GameObject TitleGamme;

    public Text MessegeInfo;


    [Header("Account")] [Space] 
    // panels
    public GameObject LoginAccountPanel;
    public GameObject ChoosePanel;
    public GameObject CreateAccountButton;
    public GameObject LoginAccountButton;
    // UI
    public Text AccountStatus;
    public Text PlayerDataName;
    public InputField PlayerName;
    public InputField PlayerPassWord;
    [SerializeField] private int MaxLetters;
    // boolenas
    private bool isPlayerNameRepeat = true;
    private bool isPlayerPasswordRepeat = true;
    // scrips
    public LevelData _levelData;
    private PlayerData _playerData;
    public DataManager _DataManager;
  

    private void Start()
    {
        LoginPanel.SetActive(true);
        ChoosePanel.SetActive(true);
        levelPanel.SetActive(false);
        ButtonPanel.SetActive(false);
        OptionPanel.SetActive(false);

    }

    private void Update()
    {
        if (LoginPanel.activeSelf == true)
        {
            PlayerDataPanel.SetActive(false);
        }
        else if (LoginPanel.activeSelf == false && PlayerDataPanel.activeSelf == false)
        {
            PlayerDataPanel.SetActive(true);
        }
        
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

    #region AdministratreAccounts

    public void LoginSelectedButton()
    {
        LoginAccountPanel.SetActive(true);
        LoginAccountButton.SetActive(true);
        ChoosePanel.SetActive(false);

        
    }
    public void CreateAccountSelectedButton()
    {
        LoginAccountPanel.SetActive(true);
        CreateAccountButton.SetActive(true);
        ChoosePanel.SetActive(false);
    }
    public void CreateNewPlayerButton()
        {
            if (PlayerName.text != String.Empty && PlayerPassWord.text != String.Empty)
            {
                if (PlayerPassWord.text.Length < MaxLetters )
                {

                    if (SaveDataManager.VerificatedPlayerName(PlayerName.text) != null)
                    {
                        isPlayerNameRepeat = false;
                        SaveDataManager.AddPlayersNamesToListNameUsed(PlayerName.text);
    
                    }
                    else
                    {
                        isPlayerNameRepeat = true;
                        AccountStatus.text = "the player's name is registered";
                    }
                }
                else
                {
                    AccountStatus.text = "the player's password exceeds the limit of characters allowed";
                }
    
                if (PlayerName.text.Length < MaxLetters)
                {
                    isPlayerPasswordRepeat = false;
                }
                else
                {
                    AccountStatus.text = "the player's name exceeds the limit of characters allowed";
                }
    
                if (isPlayerNameRepeat == false && isPlayerPasswordRepeat == false)
                {
                    CreateNewDatePlayer();
                }
    
            }
            else
            {
                AccountStatus.text = "Enter values";
            }
        }
    
        private void CreateNewDatePlayer()
        {
            // carga los nuevos datos
            _DataManager.PlayerName = PlayerName.text;
            _DataManager.PlayerPassword = PlayerPassWord.text;
            
            _playerData = new PlayerData(_DataManager);
            
            UpdatePlayerData(_playerData.PlayerName);
            SaveDataManager.SavePlayerData(_DataManager);
            
            // pasa al siguiente escenario
            LoginPanel.SetActive(false);
            TitleGamme.SetActive(true);
            ButtonPanel.SetActive(true);
        }

        public void LoginButton()
        {
            if (SaveDataManager.LoadPlayerData(PlayerName.text) != null)
            {
                PlayerData playerData = SaveDataManager.LoadPlayerData(PlayerName.text);
                
                if (playerData.PlayerPassword == PlayerPassWord.text)
                {
                    //Cargar datos
                    UpdatePlayerData(playerData.PlayerName);
                    
                    // pasa al siguiente escenario
                    LoginPanel.SetActive(false);
                    TitleGamme.SetActive(true);
                    ButtonPanel.SetActive(true);

                }
                else
                {
                    playerData = null;
                    AccountStatus.text = "Incorrect password";
                }
            }
            else
            {
                AccountStatus.text = "User does not exist";
            }
        }

        public void UpdatePlayerData(string PlayerName)
        {
            PlayerDataName.text = PlayerName;
        }
    #endregion
    
}
