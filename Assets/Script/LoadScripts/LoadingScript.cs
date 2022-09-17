using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject _ContinueButton;
    public Image _LoadinBar;
    private bool Continue = false;
    void Start()
    {
        string loadLevel = LevelLoad.NextLevel;
        
        _ContinueButton.SetActive(false);

        StartCoroutine(InicialiteLoad(loadLevel));
    }

    IEnumerator InicialiteLoad(string level)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            _LoadinBar.fillAmount = operation.progress / 0.09f;
            
            if (operation.progress >= 0.9f)
            {
                _ContinueButton.gameObject.SetActive(true);
                
                if (Continue)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    public void ContinueButtonPress()
    {
        Continue = true;
    }
}
