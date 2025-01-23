
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;
    private MenuData menuData;
    public Text BestScoreText;

    //Best player data
    public string nameBestPlayer;
    public int bestScore;
    private string playerName;

    void Start()
    {
        //I get data from the menu
        menuData = GameObject.Find("MenuData").GetComponent<MenuData>();
        playerName = menuData.playerName;

        //I load the record and I update the text displaying it.
        nameBestPlayer = "Name";
        bestScore = 0;
        LoadBestScore();
        BestScoreText.text = "Record: " + nameBestPlayer + ": " + bestScore;
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Destroy(other.gameObject);

        if (Manager.m_Points>bestScore)
        {
            SaveBestScore();
        }

        Manager.GameOver();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        nameBestPlayer = data.name;
        bestScore = data.score;
        }
    }

    private void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.score = Manager.m_Points;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
