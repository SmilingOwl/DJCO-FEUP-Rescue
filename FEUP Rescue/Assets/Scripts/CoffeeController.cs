﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        CoffeeInstantiator.instance.RemoveCoffee(gameObject);
    }
}
