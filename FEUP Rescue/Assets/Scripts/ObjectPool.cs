using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> benchPool;
    public List<GameObject> trapPool;
    public List<GameObject> dustbinPool;
    public GameObject bench;
    public GameObject trap;
    public GameObject dustbin;
    public int benchAmount = 2;
    public int trapAmount = 3;
    public int dustbinAmount = 3;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        benchPool = new List<GameObject>();
        for(int i = 0; i < benchAmount || i < trapAmount || i < dustbinAmount; i++) {
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
            if(i < dustbinAmount) {
                GameObject obj = (GameObject) Instantiate(dustbin);
                obj.SetActive(false); 
                dustbinPool.Add(obj);
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

    public GameObject GetDustbin() {
        for (int i = 0; i < dustbinPool.Count; i++) {
            if (!dustbinPool[i].activeInHierarchy) {
                return dustbinPool[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
