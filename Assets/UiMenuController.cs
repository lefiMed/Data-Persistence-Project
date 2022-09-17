using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_InputField PlayerName;
    [SerializeField] private TMP_Text BestScore;

    void Start()
    {
        BestScore.text = GameManager.Instance.topPlayerName +" : "+GameManager.Instance.topScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlayScrene()
    {
        GameManager.Instance.newPlayerName = PlayerName.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        GameManager.Instance.SaveScore();
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
