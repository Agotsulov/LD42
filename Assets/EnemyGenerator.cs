using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float delay = 1f;

    float d;
    float elapsed = 0f;

    public GameObject enemy;

    public GameObject bigEnemy;

    public GameObject spectre;

    //public GameObject block;

    public GameObject player;
    public GameObject snowForGenerate;

    public float sizeX;
    public float sizeY;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        int random = Random.Range(0, 3);

        d = delay - PlayerController.score * 0.01f;
        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = elapsed % delay;
            if (random == 0)
                GenerateEnemy();
            if (random == 1)
                GenerateBigEnemy();
            if (random == 2)
                GenerateSpectre();

        }
    }

    public void GenerateEnemy()
    {
        int dX = Random.Range(-2, 1);
        if (dX == 0)
            dX = 1;
        if (dX == -2)
            dX = -1;
        int dY = Random.Range(-2, 1);
        if (dY == 0)
            dY = 1;
        if (dY == -2)
            dY = -1;

        Vector3 v = new Vector3(Random.Range(sizeX, sizeX + 1) * dX, Random.Range(sizeY, sizeY) * dY, 0) ;
       
       
        GameObject o = Instantiate(enemy, v, Quaternion.identity);
        o.GetComponent<EnemyController>().player = this.player;
        o.GetComponent<EnemyController>().snow = this.snowForGenerate;
    }

    public void GenerateSpectre()
    {
        int dX = Random.Range(-2, 1);
        if (dX == 0)
            dX = 1;
        if (dX == -2)
            dX = -1;
        int dY = Random.Range(-2, 1);
        if (dY == 0)
            dY = 1;
        if (dY == -2)
            dY = -1;

        Vector3 v = new Vector3(Random.Range(sizeX, sizeX + 1) * dX, Random.Range(sizeY, sizeY) * dY, 0);


        GameObject o = Instantiate(spectre, v, Quaternion.identity);
        o.GetComponent<SpectreController>().player = this.player;
    }

    public void GenerateBigEnemy()
    {
        int dX = Random.Range(-2, 1);
        if (dX == 0)
            dX = 1;
        if (dX == -2)
            dX = -1;
        int dY = Random.Range(-2, 1);
        if (dY == 0)
            dY = 1;
        if (dY == -2)
            dY = -1;

        Vector3 v = new Vector3(Random.Range(sizeX, sizeX + 1) * dX, Random.Range(sizeY, sizeY) * dY, 0);

        GameObject o = Instantiate(bigEnemy, v, Quaternion.identity);
        o.GetComponent<BigEnemyController>().player = this.player;
        //o.GetComponent<BigEnemyController>().block = this.block;
        //o.GetComponent<BigEnemyController>().snow = this.snowForGenerate;
    }
}
