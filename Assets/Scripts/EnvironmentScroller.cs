using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScroller : MonoBehaviour
{
    private Vector2 startPos = new Vector2(9.37f,-4.4f);
    private Vector2 endPos = new Vector2(-18.37f, -4.4f);


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, endPos, Time.deltaTime * .5f);
        //transform.position = Vector2.Lerp()
    }
}
