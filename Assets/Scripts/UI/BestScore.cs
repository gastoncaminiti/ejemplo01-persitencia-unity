using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text bestText;
    void Start()
    {
        GameManager.Instance.LoadJSON();
        bestText.text = "Best Score: "+ GameManager.Instance.GetName() + " : " + GameManager.Instance.GetBest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
