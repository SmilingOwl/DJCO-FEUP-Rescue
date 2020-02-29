using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float background_speed = 0.3f;
    public Renderer background_renderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        background_renderer.material.mainTextureOffset += new Vector2(background_speed * Time.deltaTime, 0f);
    }
}
