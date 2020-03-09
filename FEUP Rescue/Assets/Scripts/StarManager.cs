using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;
    public GameObject[] stars;
    int defeatedThieves;
    
    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    void Reset() {
        defeatedThieves = 0;
        for(int i = 0; i < stars.Length; i++) {
            stars[i].SetActive(false);
        }
    }

    public void FillStar() {
        defeatedThieves++;
        if(defeatedThieves > 5)
            return;
        
        stars[defeatedThieves-1].SetActive(true);
    }
}
