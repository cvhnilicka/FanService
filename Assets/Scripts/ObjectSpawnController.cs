using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public GameObject rock1;
    public GameObject tree1;


    private float spawnTimer;
    private float spawnTime = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Timer())
            Spawner();
    }

    bool Timer()
    {

        // todo: need to add in increasing difficulty
        // score < X : timer ever 2f
        // score > X < Y: Timer set shorter
        // score > y : timer even shorter


        if (spawnTimer <= 0)
        {
            bool isNeg = (Random.value > 0.5f);
            float delta = Random.Range(0.01f, 0.3f);
            if (isNeg)
                delta *= -1;
            spawnTimer = spawnTime + delta;
            return true;
        }
        else
        {

            spawnTimer -= Time.deltaTime;
            return false;
        }
    }

    void Spawner()
    {


        bool isRock = (Random.value > 0.5f);

        if (isRock)
        {
            GameObject.Instantiate(rock1, rock1.GetComponent<EnvironmentScroller>().startPos, Quaternion.identity);
        }
        else
        {
            GameObject.Instantiate(tree1, tree1.GetComponent<EnvironmentScroller>().startPos, Quaternion.identity);
        }
    }
}
