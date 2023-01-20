using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {   /* 
         * horizontal (-1 - 0) we are moving left A
         * horizontal (0 - 1) we are moving right D
         * vertical ( -1 - 0 ) we are moving backwards S
         * vertical (0 - 1) we are moving forwards W
         */
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        //Left Right moving
        transform.Translate(fHorizontal * speed * Vector3.right * Time.deltaTime);
        //Forwards Backward
        transform.Translate(fVertical * speed * Vector3.forward * Time.deltaTime);
    }
}
