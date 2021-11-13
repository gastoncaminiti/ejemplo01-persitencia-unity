using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;

    private int    bestScore;
    private string username;

    void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        bestScore = 0;
        username = "JOE";
    }

    [System.Serializable]
    class SaveData
    {
        public int    BestScore;
        public string Username;
    }

    public void SaveJSON()
    {
        SaveData data = new SaveData();

        data.BestScore = bestScore;
        data.Username  = username;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadJSON()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.BestScore;
            username  = data.Username;
        }
    }

    public void SetName(string newUsername)
    {
        Instance.username = newUsername;
    }

    public void SetBestScore(int newScore)
    {
        if(newScore > bestScore)
        {
            Instance.bestScore = newScore;
        }
    }

   public string GetName()
    {
        return Instance.username;
    }

    public int GetBest()
    {
        return Instance.bestScore;
    }
}
