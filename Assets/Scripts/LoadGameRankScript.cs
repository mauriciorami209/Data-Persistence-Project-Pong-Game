using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LoadGameRankScript : MonoBehaviour
{
    // Fields for displaying player info
    public Text BestPlayerName;

    // Static variables for holding the best player data
    private static int BestScore;
    private static string BestPlayer;

    private void Awake()
    {
        // Call LoadGameRank() when the script starts
        LoadGameRank();
    }

    private void SetBestPlayer()
    {
        // Check if there's no best player and no best score
        if (BestPlayer == null && BestScore == 0)
        {
            BestPlayerName.text = "";
        }
        else
        {
            // Display the best player's name and score in the UI text element
            BestPlayerName.text = $"Best Score - {BestPlayer}: {BestScore}";
        }
    }

    public void LoadGameRank()
    {
        // Define the path to the JSON file for saving and loading data
        string path = Application.persistentDataPath + "/savefile.json";

        // Check if the save file exists
        if (File.Exists(path))
        {
            // Read the JSON content from the file
            string json = File.ReadAllText(path);

            // Deserialize the JSON data into a SaveData object using JsonUtility
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Retrieve the best player and best score from the loaded data
            BestPlayer = data.TheBestPlayer;
            BestScore = data.HighiestScore;

            // Update the UI with the best player's information
            SetBestPlayer();
        }
    }

    // Serializable class for saving and loading data
    [System.Serializable]
    class SaveData
    {
        public int HighiestScore;
        public string TheBestPlayer;
    }
}

