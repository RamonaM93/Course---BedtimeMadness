using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour, IActorTemplate
{
    [SerializeField]SOActorModel actorModel;

    //Actor values
    float speed;
    int health;
    int hitPower;
    int score;
    SOActorModel.ActorType actorType;
    [SerializeField]protected NavMeshAgent agent;

    //Chase variables
    private float distanceToPlayer;

    //Facing values
    Vector3 directionToPlayer;
    float angle;
    [SerializeField]float minDistanceToPlayer = 2.0f;

    protected GameObject bullet;

    GameObject actor;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        actor = actorModel.actor;
        actorType= actorModel.actorType;
        bullet = actorModel.actorBullet;
        score = actorModel.score;   
    }

    public void Die()
    {
        Destroy(gameObject);

        if (actorType == SOActorModel.ActorType.BossTeddyBear)
        {
            GameManager.Instance.GetComponent<ScenesManager>().GameOver();
            //Custom sequence - write code here
        }
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            if (health >= 1) health -= collision.gameObject.GetComponent<IActorTemplate>().SendDamage();
            if (health <= 0) Die();

            GameManager.Instance.GetComponent<ScoreManager>().SetScore(score);
            LevelUI.onScoreUpdate?.Invoke();
        }
    }

    public bool LookingAtPlayer()
    {
        //Calculating if we are facing the player
       directionToPlayer = transform.position - GameManager.playerPosition;
       angle = Vector3.Angle(transform.forward, directionToPlayer);
      
        //Calculating the distance to the plater
       distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition);

       if (distanceToPlayer < minDistanceToPlayer && FacingPlayer())
       {
          return true;
       }
        else return false;
    }

    public void Chase()
    { 
        agent.destination=GameManager.playerPosition;
    }

    bool FacingPlayer()
    {
      if (Mathf.Abs(angle) > 90.0f && Mathf.Abs(angle) < 270.0f) return true;
      else return false;
    }


}

