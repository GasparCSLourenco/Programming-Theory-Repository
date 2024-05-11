using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    public static MenuHandler Instance { get; private set; }
    public TMP_InputField nameInput;
    public TextMeshProUGUI highScoreText;

    public string playerName;
    public int score;
    public int highScore;
    public string highName;

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }


    
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
        highScoreText.text = $"High Score: {highScore} by {highName}"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SaveInfo();
        SceneManager.LoadScene(1);
    }

    void SaveInfo()
    {
        playerName = nameInput.text;
    }

    public void SaveHighScore(string name, int points)
    {
		SaveData saveDate = new SaveData
		{
			name = name,
			score = points
		};

		string json = JsonUtility.ToJson(saveDate);
        File.WriteAllText(Application.persistentDataPath + "/scores.json", json);
    }

    void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            highScore = saveData.score;
            highName = saveData.name;
        }
    }
}
