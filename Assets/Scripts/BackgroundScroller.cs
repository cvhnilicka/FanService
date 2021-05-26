using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed = 0f;
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        renderer.material.mainTextureOffset = new Vector2((speed * Time.time) % 1, 0f);
    }
}
