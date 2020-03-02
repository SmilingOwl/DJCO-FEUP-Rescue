using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> benchPool;
    public List<GameObject> trapPool;
    public GameObject bench;
    public GameObject trap;
    public int benchAmount = 2;
    public int trapAmount = 3;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        benchPool = new List<GameObject>();
        for(int i = 0; i < benchAmount && i < trapAmount; i++) {
            if(i < benchAmount) {
                GameObject obj = (GameObject) Instantiate(bench);
                obj.SetActive(false); 
                benchPool.Add(obj);
            }
            if(i < trapAmount) {
                GameObject obj = (GameObject) Instantiate(trap);
                obj.SetActive(false); 
                trapPool.Add(obj);
            }
        }
    }

    public GameObject GetBench() {
        for (int i = 0; i < benchPool.Count; i++) {
            if (!benchPool[i].activeInHierarchy) {
                return benchPool[i];
            }
        }
        return null;
    }

    public GameObject GetTrap() {
        for (int i = 0; i < trapPool.Count; i++) {
            if (!trapPool[i].activeInHierarchy) {
                return trapPool[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
