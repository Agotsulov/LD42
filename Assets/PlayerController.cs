using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speedOnGround = 4;
    public float speedOnSnow = 2;
    public float distance = 3;
    public float distanceOfSnow = 3;
    public float delayOfSpeed = 2;

    public float time = 0;

    public GameObject snowThrowable;
    public int needToThrow = 1;
    public float speedOfThrow = 5;

    public GameObject block;
    public float distanceOfBuild = 3;
    public int needToBuild = 1;

    public int hp = 3;
    public float score = 0;

    public Text textHp;
    public Text textScore;

    public float delay = 1f;

    float elapsed = 0f;

    Rigidbody2D rb;

    GameObject[] gos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (hp <= 0)
            Destroy(this.gameObject);

        textHp.text = "HP:" + hp;
        textScore.text = "Score:" + score;


        gos = GameObject.FindGameObjectsWithTag("Snow");

        float speed = speedOnSnow;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");



        elapsed += Time.deltaTime;
        if (elapsed >= delay)
        {
            elapsed = elapsed % delay;
            score++;

            time++;
        }

        if (time >= delayOfSpeed)
        {
            speed = speedOnGround; 
        }

        rb.velocity = new Vector2(x * speed, y * speed);

    }

    void Update ()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Vector2 dir = mousePos2D - new Vector2(this.transform.position.x, this.transform.position.y);
 

        var angle = Vector2.Angle(Vector2.right, mousePos - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePos.y ? angle : -angle);


        if (Input.GetButtonDown("Fire1"))
        {
            List<GameObject> os = new List<GameObject>();
            //GameObject[] gos;
            //gos = GameObject.FindGameObjectsWithTag("Snow");
        
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    os.Add(go);
                }
            }


            

            if (os.Count >= needToThrow)
            {
                GameObject o = Instantiate(snowThrowable, this.transform.position, Quaternion.identity);
                o.GetComponent<Rigidbody2D>().velocity = dir.normalized * speedOfThrow;

                time = 0;

                foreach (GameObject go in os)
                {
                    Destroy(go);
                }
            }
        } else if (Input.GetButtonDown("Fire2"))
        {
            List<GameObject> os = new List<GameObject>();
            //GameObject[] gos;
            //gos = GameObject.FindGameObjectsWithTag("Snow");

            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distanceOfBuild)
                {
                    os.Add(go);
                }
            }

            if (os.Count >= needToBuild)
            {
                Vector3 t = mousePos;
                t = Quaternion.Euler(0f, 0f, transform.position.y < mousePos.y ? angle : -angle) * t;



                GameObject o = Instantiate(block, t, Quaternion.identity);
                o.GetComponent<Rigidbody2D>().velocity = dir.normalized * speedOfThrow;

                time = 0;

                foreach (GameObject go in os)
                {
                    Destroy(go);
                }
            }
        }

    }
}
