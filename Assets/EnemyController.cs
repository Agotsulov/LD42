using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 10;

    public GameObject player;

    public GameObject snow;
    public float delay = 0.1f;

    public float size = 0.2f;

    float elapsed = 0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 dir = player.transform.position - this.transform.position;
        rb.velocity = dir.normalized * speed;

        var angle = Vector2.Angle(Vector2.right, player.transform.position - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < player.transform.position.y ? angle : -angle);
        
        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = elapsed % delay;
            Generate();
        }
    }

    public void Generate()
    {
        Vector3 v = this.gameObject.transform.position + new Vector3(Random.Range(-size, size), Random.Range(-size, size), 0);
        GameObject o = Instantiate(snow, v, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().hp--;
            Destroy(this.gameObject);
        }
    }

}
