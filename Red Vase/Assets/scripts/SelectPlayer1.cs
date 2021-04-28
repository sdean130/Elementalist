using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer1 : MonoBehaviour {

    public float curHealth;
    int maxHealth;
    static int dps;
    static int player1id;
    string Name;
    float moveSpeed;
    float attSpeed;
    float armor;


    float attackCD;
    float attackTimer;
    bool attacking;
    public Collider2D attackTrigger;

	void Awake()
	{
        attackTrigger.enabled = false;
	}

	void Start () 
    {
        player1id = game.SP1;
        playerOptions PO = playerOptions.Load("playerData");
        // loop through each player in playerOptions
        // when id == selectedPlayer1.ID 
        // set everything else thats belongs to that playerOption equal to this players att's
        foreach (player Player in PO.players)
        {
            if(Player.ID == player1id)
            {
                maxHealth = Player.Health;
                Name = Player.CharName;
                dps = Player.Dps;
                moveSpeed = 600 * Player.MoveSpeed;
                attSpeed = Player.AttSpeed;
                armor = Player.Armor;
            }
        }
        curHealth = maxHealth;
        attacking = false;
        attackCD = .03f;
        attackTimer = 0;
	}

	static Vector3 Position;
    public static Vector3 position
    {
        get { return Position; }
        set { Position = value; }
    }

    public static int Deeps
    {
        get { return dps; }
        set { dps = value; }
    }

    public static int p1ID
    {
        get { return player1id; }
        set { player1id = value; }
    }

    void FixedUpdate()
    {   
        Position = this.transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().AddForce((Vector2.right * moveSpeed) * Time.deltaTime);
            Position = this.transform.position;
            GameObject.FindGameObjectWithTag("attackTrigger1").transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().AddForce((-Vector2.right * moveSpeed)*Time.deltaTime);
            Position = this.transform.position;
            GameObject.FindGameObjectWithTag("attackTrigger1").transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody2D>().AddForce((Vector2.up * moveSpeed)* Time.deltaTime);
            Position = this.transform.position;
            GameObject.FindGameObjectWithTag("attackTrigger1").transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Rigidbody2D>().AddForce((-Vector2.up * moveSpeed)*Time.deltaTime);
            Position = this.transform.position;
            GameObject.FindGameObjectWithTag("attackTrigger1").transform.rotation = Quaternion.Euler(0, 0, 0);
        }

	}
	void Update()
    {
        if (Input.GetKey(KeyCode.E) && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;

            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
        if(Input.GetKey(KeyCode.F))
        {
            if(!game.HaveVase)
            {
                if (game.IsVase)
                {
                    game.HaveVase = true;
                    Destroy(GameObject.FindGameObjectWithTag("vase"));
                }else if (game.IsVase2)
                {
                    game.HaveVase = true;
                    Destroy(GameObject.FindGameObjectWithTag("vase2"));
                }else if (game.IsVase3)
                {
                    game.HaveVase = true;
                    Destroy(GameObject.FindGameObjectWithTag("vase3"));
                }else if (game.IsVase4)
                {
                    game.HaveVase = true;
                    Destroy(GameObject.FindGameObjectWithTag("vase4"));
                }else if (game.IsVase5)
                {
                    game.HaveVase = true;
                    Destroy(GameObject.FindGameObjectWithTag("vase5"));
                }else if (game.IsVase6)
                {
                    game.HaveVase = true;
                    Destroy(GameObject.FindGameObjectWithTag("vase6"));
                }
            }
        }
	}

	private void OnCollisionEnter2D(Collision2D c)
	{
        Vector2 shove = c.gameObject.transform.position - transform.position;
        if(c.gameObject.name == "goblin")
        {
            curHealth -= 20 * armor;
            this.GetComponent<Rigidbody2D>().AddForce(-shove*700);
        }
        if(c.gameObject.name == "bat")
        {
            curHealth -= 10 * armor;
        }

	}

}
