using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> benchPool;
    public GameObject bench;
    public int benchAmount = 1;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        benchPool = new List<GameObject>();
        for(int i = 0; i < benchAmount; i++) {
            GameObject obj = (GameObject) Instantiate(bench);
            obj.SetActive(false); 
            benchPool.Add(obj);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
