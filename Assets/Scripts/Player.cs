using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate
{
    float speed;
    int health;
    int hitPower;
    GameObject actor;
    GameObject bullet;

    //Bullet properties
    [SerializeField] private GameObject shootingPoint;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameStates.Play)
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
    }

    void Move()
    {                
        /* 
         * horizontal (-1 - 0) we are moving left A
         * horizontal (0 - 1) we are moving right D
         * vertical ( -1 - 0 ) we are moving backwards S
         * vertical (0 - 1) we are moving forwards W
         */
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Left Right moving
        transform.Translate(horizontal * speed * Vector3.right * Time.deltaTime);
        //Forwards Backward
        transform.Translate(vertical * speed * Vector3.forward * Time.deltaTime);
    }

    void Attack()
    {
        Instantiate(bullet, shootingPoint.transform.position, shootingPoint.transform.rotation);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;

        actor= actorModel.actor;
        bullet= actorModel.bullet;
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}