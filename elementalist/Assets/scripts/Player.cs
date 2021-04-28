using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour 
{
    int moveSpeed;
    int upDown;
    int leftRight;
    public int curScene;
    Vector3 oldPos;
    public bool inCombat;

	void Start () 
    {
        moveSpeed = 480;
        DontDestroyOnLoad(this.gameObject);
        inCombat = false;

    }

    void SetOldPos()
    {

    }

	static Vector3 Position;
    public static Vector3 position
    {
        get { return Position; }
        set { Position = value; }
    }

    void FixedUpdate()
    {
        if (!inCombat)
        {
            Position = this.transform.position;
            {
                upDown = (int)Input.GetAxisRaw("Vertical");
                leftRight = (int)Input.GetAxisRaw("Horizontal");

                if (Input.GetKey(KeyCode.D) || leftRight == 1)
                {
                    this.GetComponent<Rigidbody2D>().AddForce((Vector2.right * moveSpeed) * Time.deltaTime);
                    Position = this.transform.position;
                }

                if (Input.GetKey(KeyCode.A) || leftRight == -1)
                {
                    this.GetComponent<Rigidbody2D>().AddForce((-Vector2.right * moveSpeed) * Time.deltaTime);
                    Position = this.transform.position;
                }

                if (Input.GetKey(KeyCode.W) || upDown == 1)
                {
                    this.GetComponent<Rigidbody2D>().AddForce((Vector2.up * moveSpeed) * Time.deltaTime);
                    Position = this.transform.position;
                }

                if (Input.GetKey(KeyCode.S) || upDown == -1)
                {
                    this.GetComponent<Rigidbody2D>().AddForce((-Vector2.up * moveSpeed) * Time.deltaTime);
                    Position = this.transform.position;
                }

                curScene = SceneManager.GetActiveScene().buildIndex;
            }
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "upLadder")
        {
            gameObject.transform.position = new Vector3(17.6f, 1.64f, -.1f);

        }
        else if(collision.tag == "downLadder")
        {
            gameObject.transform.position = new Vector3(2.5f, 1.45f, -.1f);
        }
        else if (collision.tag == "enterTemple")
        {
            gameObject.transform.position = new Vector3(-1.0f, -1.75f, -.1f);
            SceneManager.LoadScene(2);
        }
        else if (collision.tag == "backToForest")
        {
            gameObject.transform.position = new Vector3(-0.3f, 2.1f, -.1f);
            SceneManager.LoadScene(1);
        }

    }
}