using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScroller : MonoBehaviour
{
    public Vector2 startPos = new Vector2(0,0);
    public Vector2 endPos = new Vector2(0, 0);


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, endPos, Time.deltaTime * .65f);
        //transform.position = Vector2.Lerp()
    }
}
