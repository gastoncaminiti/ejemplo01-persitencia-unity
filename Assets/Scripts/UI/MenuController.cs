using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TextMeshProUGUI    bestText;
    void Start()
    {
        GameManager.Instance.LoadJSON();
        username.text = GameManager.Instance.GetName();
        bestText.text = "Best Score: " + GameManager.Instance.GetBest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEndedInputField()
    {
        GameManager.Instance.SetName(username.text);
        GameManager.Instance.SaveJSON();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
