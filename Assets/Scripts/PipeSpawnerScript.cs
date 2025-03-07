using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    public float heightOffset = 12.5f;
    private float timer=0;
    public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        createPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logicScript.isGameOver)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                createPipe();
                timer = 0;
            }
        }
    }

    void createPipe()
    {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;
        Debug.Log(highestPoint +" l "+ lowestPoint);

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}