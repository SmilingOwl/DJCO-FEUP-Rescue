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
    public GameObject[] numbers;
    public GameObject points;
    
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

    public void ShowPoints(int score) {
        List<int> pts = new List<int>();
        while(score != 0) {
            pts.Add((int) (score % 10));
            score = (int)(score / 10);
        }

        for(int i = pts.Count - 1; i >= 0; i--) {
            GameObject num = (GameObject) Instantiate(numbers[pts[i]]);
            num.SetActive(true);
            num.transform.parent = points.transform;
        }
    }

}
