using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Panels")]
    [Space]
    public GameObject LoginPanel;
    public GameObject PlayerDataPanel;
    public GameObject ButtonPanel;
    public GameObject levelPanel;
    public GameObject OptionPanel;
    public GameObject messege;
    public GameObject TitleGamme;
    public GameObject ScorePanel;

    public Text MessegeInfo;

    #region Account

   
        // Conditions
        public static bool isChangeAccount = false;
        public static bool isConnectAccount = false;
    
        public static string SavePlayerName;
        public static string SavePlayerPassword;
        
        [Header("Account UI ")] 
        [Space]
        // panels
        public GameObject LoginAccountPanel;
        public GameObject ChoosePanel;
        public GameObject CreateAccountButton;
        public GameObject LoginAccountButton;
        // UI
        public Text AccountStatus;
        
        public InputField PlayerName;
        public InputField PlayerPassWord;
        
        [SerializeField] private int MaxLetters;
        // boolenas
        private bool isPlayerNameRepeat = true;
        private bool isPlayerPasswordRepeat = true;
        // scrips
        public LevelData _levelData;
        public PlayerData _playerData;
        public DataManager _DataManager;
        
        [Header("User Data")] 
        [Space] 
        public Text PlayerStars;
        public Text PlayerDataName;
    
        public int TotalStarsWantCollect;

    #endregion

  
    private void Start()
    {
        SaveDataManager.GetNames();
        
        Debug.Log(SaveDataManager.PlayerNames.Count);
        Debug.Log(SaveDataManager.PlayersRegister);
        #region Panels

            LoginPanel.SetActive(true);
                ChoosePanel.SetActive(true);
                levelPanel.SetActive(false);
                ButtonPanel.SetActive(false);
                OptionPanel.SetActive(false);
                ScorePanel.SetActive(false);

        #endregion
    
        #region LoadData

             _playerData = SaveDataManager.LoadPlayerData(SavePlayerName);
                UploadData(_playerData.PlayerName, _playerData.PlayerPassword, _playerData.AllCollectionPlayerStars);
                UpdatePlayerData(_playerData.PlayerName, _playerData.AllCollectionPlayerStars);

            #endregion
   
         
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


        #region Connected_Account
        //  Activate Player Data Account
            if (LoginPanel.activeSelf == true)
            {
                PlayerDataPanel.SetActive(false);
            }
            else if (LoginPanel.activeSelf == false && PlayerDataPanel.activeSelf == false)
            {
                PlayerDataPanel.SetActive(true);
            }
            // verification Status Account
            if (_DataManager.PlayerName != String.Empty && _DataManager.PlayerPassword != String.Empty)
            {
                isConnectAccount = true;
            }
            else
            {
                isConnectAccount = false;
            }
            
            if (isConnectAccount == false && LoginPanel.activeSelf == false ) ReturnLoginAccountButton();
            
            if (isConnectAccount == true && LoginPanel.activeSelf == true)
            {
                LoginPanel.SetActive(false);
                TitleGamme.SetActive(true);
                ButtonPanel.SetActive(true);
            }
           

        #endregion
    
        
    }

    #region Buttons_Menu

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
            ScorePanel.SetActive(false);

        }

        public void ScoreButton()
        {
            ScorePanel.SetActive(true);
            ButtonPanel.SetActive(false);
        }

        #endregion
   

    #region AdministratreAccounts

    #region Buttons_Account

     public void ReturnCreateOrLogedAccount()
        {
            ChoosePanel.SetActive(true);
            LoginAccountPanel.SetActive(false);
            CreateAccountButton.SetActive(false);
        }
    
        public void ReturnLoginAccountButton()
        {
            ResetData();
            isConnectAccount = false;
            _playerData = null;
            LoginPanel.SetActive(true);
            ChoosePanel.SetActive(true);
            TitleGamme.SetActive(false);
            ButtonPanel.SetActive(false);
            LoginAccountPanel.SetActive(false);
            CreateAccountButton.SetActive(false);
            PlayerDataPanel.SetActive(false);
            
        }

        private void ResetData()
        {
            _DataManager.PlayerName = String.Empty;
            _DataManager.PlayerPassword = String.Empty;
            _DataManager.AllPlayerStars = 0;
        }
          public void LoginSelectedButton()
            {
                LoginAccountPanel.SetActive(true);
                LoginAccountButton.SetActive(true);
                ChoosePanel.SetActive(false);
            }
        
            public void PasswordVisualizationButton()
            {
                PlayerPassWord.contentType = PlayerPassWord.contentType == InputField.ContentType.Name ? InputField.ContentType.Password : InputField.ContentType.Name;
            }
            public void CreateAccountSelectedButton()
            {
                LoginAccountPanel.SetActive(true);
                CreateAccountButton.SetActive(true);
                LoginAccountButton.SetActive(false);
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
                        Debug.Log(PlayerName.text);
                        
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
    #endregion

    #region Load_Data_And_Create_Data

        private void CreateNewDatePlayer()
            {
                isChangeAccount = true;
    
                #region Load_DATA
    
                 // carga los nuevos datos
                            
                            _playerData = new PlayerData(_DataManager);
                            SavePlayerName = PlayerName.text;
                            SavePlayerPassword = PlayerPassWord.text;
                            UpdatePlayerData(PlayerName.text,_playerData.AllCollectionPlayerStars);
                            UploadData(PlayerName.text, PlayerPassWord.text, 0);
                            Debug.Log(PlayerName.text);
                            Debug.Log(SavePlayerName);
                            SaveDataManager.SavePlayerData(_DataManager);
                            SaveDataManager.SetNames();
    
                    #endregion
    
                #region Pass_Menu
    
                       // pasa al siguiente escenario
                                LoginPanel.SetActive(false);
                                TitleGamme.SetActive(true);
                                ButtonPanel.SetActive(true);
    
                    #endregion
             
            }
    
        public void LoginButton()
            {
                if (SaveDataManager.LoadPlayerData(PlayerName.text) != null)
                {
                    PlayerData playerData = SaveDataManager.LoadPlayerData(PlayerName.text);
                    
                    if (playerData.PlayerPassword == PlayerPassWord.text)
                    {
                        isChangeAccount = true;
                        SavePlayerPassword = playerData.PlayerPassword;
                        //Cargar datos
                        UpdatePlayerData(playerData.PlayerName,playerData.AllCollectionPlayerStars);
                        UploadData(playerData.PlayerName, playerData.PlayerPassword, playerData.AllCollectionPlayerStars);
                        
                        // Load name
                        SaveDataManager.SetNames();
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

    #endregion
    
    #region UpdateData

                private void UpdatePlayerData(string PlayerName, int playerStars)
                {
                    Debug.Log(PlayerDataName.text);
                    Debug.Log("nombre cargado");

                    PlayerDataName.text = PlayerName;
                    PlayerStars.text ="Stars :" + playerStars +" / " + TotalStarsWantCollect;
                    SavePlayerName = PlayerName;
                }
        
                private void UploadData(string playername, string playerPassword, int stars)
                {
                    _DataManager.PlayerName = playername;
                    _DataManager.PlayerPassword = playerPassword;
                    _DataManager.AllPlayerStars = stars;
                }

        #endregion
      
    #endregion
    
}
