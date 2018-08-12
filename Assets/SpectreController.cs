using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectreController : MonoBehaviour {

    public float speed = 6;

    public GameObject player;
    public GameObject snow;

    public float delay = 5f;

    float elapsed = 0f;

    public float size = 0.2f;
    public float generDir = 0.2f;

    Rigidbody2D rb;
    Vector2 target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = player.transform.position;
    }

    void Update()
    {
        if (GetComponent<HP>().hp <= 0)
        {
            Destroy(this.gameObject);
        }

        Vector2 dir = target - (Vector2) this.transform.position;
        rb.velocity = dir.normalized * speed;

        if (dir.sqrMagnitude < generDir)
            Generate();

        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = elapsed % delay;
            FindTarget();
        }
    }
    public void Generate()
    {
        Vector3 v = this.gameObject.transform.position + new Vector3(Random.Range(-size, size), Random.Range(-size, size), 0);
        GameObject o = Instantiate(snow, v, Quaternion.identity);
    }


    void FindTarget()
    {
        target = player.transform.position;
        var angle = Vector2.Angle(Vector2.right, player.transform.position - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < player.transform.position.y ? angle : -angle);
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
