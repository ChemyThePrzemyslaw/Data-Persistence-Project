using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class MenuData : MonoBehaviour
{
    
    public string playerName;
    public TMP_InputField playerNameInputField;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        playerName = playerNameInputField.text;
        SceneManager.LoadScene(1);
    }


}
