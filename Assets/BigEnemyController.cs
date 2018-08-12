using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{

    public float speed = 10;

    public GameObject player;

    public GameObject block;
    public GameObject snow;

    public float size = 0.2f;
   

    Rigidbody2D rb;

    Vector3 target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(GetComponent<HP>().hp <= 0)
        {
            Generate();
            Destroy(this.gameObject);
        }

        target = ((Vector2)player.transform.position); // + player.GetComponent<Rigidbody2D>().velocity.normalized * 2;
        Vector2 dir = target - this.transform.position;
        rb.velocity = (dir.normalized * speed);

        var angle = Vector2.Angle(Vector2.right, player.transform.position - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < player.transform.position.y ? angle : -angle);


    }

    public void Generate()
    {
        Vector3 v = this.gameObject.transform.position;
        GameObject o = Instantiate(block, v, this.transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<HP>().hp--;
            Destroy(this.gameObject);
        }
    }
}
