using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public TextMeshProUGUI text;
    int score;
    
    // Start is called before the first frame update
    void Start()
    {
        if(scoreManager == null)
        {
            scoreManager = this;
        }
    }

   public void UpdateScore(int pcs)
    {
        score = pcs;
        text.text = "X" + score.ToString();
    }

}
