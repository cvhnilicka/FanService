using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public GameObject rock1;
    public GameObject tree1;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(rock1, rock1.GetComponent<EnvironmentScroller>().startPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
