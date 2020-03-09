using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public static BombManager instance;
    public GameObject bomb;
    public bool isBombActive;
    
    void Awake() {
        instance = this;
    }
    
    void Start()
    {
        bomb.SetActive(false);
        isBombActive = false;
    }

    public void ActivateBomb() {
        bomb.SetActive(true);
        isBombActive = true;
    }

    void Update() {
        if (isBombActive && Input.GetKeyDown(KeyCode.B))
        {
            bomb.SetActive(false);
            isBombActive = false;
            BombAttack.instance.Attack();
        }
    }
}
