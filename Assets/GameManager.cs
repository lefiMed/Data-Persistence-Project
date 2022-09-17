using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public string topPlayerName { get; set; }
    public string newPlayerName { get; set; }
    public int topScore { get; set; }
   
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class Score
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveScore()
    {
        Score score = new Score();
        score.bestScore = topScore;
        score.playerName = topPlayerName;

        string json = JsonUtility.ToJson(score);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Score score = JsonUtility.FromJson<Score>(json);

            topPlayerName = score.playerName;
            topScore = score.bestScore;
        }
    }
}
