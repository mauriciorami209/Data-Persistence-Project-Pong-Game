using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

 
public class MenuUIHandler : MonoBehaviour
{
    //This is the handler of the main menu scene

    [SerializeField] Text PlayerNameInput;

    public void StartGame()
    {

        // Load the game scene
        SceneManager.LoadScene("main");
    }

    public void SetPlayerName(string PlayerNameInput)
    {
        // PlayerDataHandle.Instance.PlayerName = PlayerNameInput.text;
        PlayerDataHandle.Instance.PlayerName = PlayerNameInput;
        Debug.Log(PlayerNameInput);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}



