using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Create Actor",menuName ="Create Actor")]

public class SOActorModel : ScriptableObject
{
    public string description;

    //Give our actor a name
    public string actorName;

    //enum allows us to define custom data types
    public enum ActorType
    {
        Player,
        SmallTeddyBear,
        BigTeddyBear,
        BossTeddyBear,
        Bullet,
     }

    public ActorType actorType;

    public int health;
    public float speed;
    public int hitPower;
    public int score;
    public string colourName;

    public GameObject actor;
    public GameObject bullet;

   }

