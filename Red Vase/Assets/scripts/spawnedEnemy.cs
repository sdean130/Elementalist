using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnedEnemy : MonoBehaviour
{

    public float curHealth;
    int maxHealth;
    int dps;
    int enemyid;
    static string Name;
    float moveSpeed;
    float attSpeed;
    float armor;

    Vector3 target;
    float tDistance;
    public float seekRange;

    void Start()
    {
        Name = this.name;
        enemyOptions EO = enemyOptions.Load("enemyData");
        foreach (enemy Enemy in EO.enemies)
        {
            if (Enemy.EnemyName == Name)
            {
                maxHealth = Enemy.Health;
                Name = Enemy.EnemyName;
                enemyid = Enemy.ID;
                dps = Enemy.Dps;
                moveSpeed = 600 * Enemy.MoveSpeed;
                attSpeed = Enemy.AttSpeed;
                armor = Enemy.Armor;
            }
        }
        curHealth = maxHealth;
    }

	void Update () 
    {
        if(Vector3.Distance(transform.position, SelectPlayer1.position) 
           < Vector3.Distance(transform.position, SelectPlayer2.position))
        {
            target = SelectPlayer1.position;
        }
        else
        {
            target = SelectPlayer2.position;
        }
        tDistance = Vector2.Distance(transform.position, target);
        if(tDistance < seekRange)
        {
            // for animations
            // going left x is negative, going right x is positive
            // for up down
            // up and left x is negative y is positive
            // down and left x is negative y is negative
            // up and right x is positive y is positive
            // down and right x is positive y is negative
            Vector3 toPlayer = Vector3.Normalize(target - transform.position);
            this.GetComponent<Rigidbody2D>().AddForce(toPlayer * Time.deltaTime * moveSpeed);

        }

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
	void OnTriggerEnter2D(Collider2D C)
	{
        if(C.gameObject.tag == "attackTrigger1")
        {
            curHealth -= SelectPlayer1.Deeps * armor;
            if (SelectPlayer1.p1ID == 4 || SelectPlayer1.p1ID == 2)
            {
                this.GetComponent<Rigidbody2D>().AddForce(-(C.gameObject.transform.position - transform.position) * 250);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().AddForce(-(C.gameObject.transform.position - transform.position) * 500);
            }
        }
        if(C.gameObject.tag == "attackTrigger2")
        {
            curHealth -= SelectPlayer2.Deeps * armor;
            if(SelectPlayer2.p2ID == 4 || SelectPlayer2.p2ID == 2)
            {
                this.GetComponent<Rigidbody2D>().AddForce(-(C.gameObject.transform.position - transform.position) * 250);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().AddForce(-(C.gameObject.transform.position - transform.position) * 500);   
            }
        }
    }
}
