using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Animator controller object
    [SerializeField] Animator animator;

    float horizontal;
    float vertical;

    bool shooting = false;
    
    // Start is called before the first frame update
    void Start()
    {   
        //Capturing the movement input
        animator.GetComponentInChildren<Animator>();
        
        //Applying the movement input to our animations
        UpdateAnimations(0.0f, 0.0f);        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameStates.Play)
        {
            //Capturing the movement input
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            //Applying the movement input to our animations
            UpdateAnimations(vertical, horizontal);

            if (Input.GetButtonDown("Fire1")) Shoot();
            else if (Input.GetButtonUp("Fire1")) Shoot();
        }
    }

    public void UpdateAnimations(float h, float v)
    {
        animator.SetFloat("horizontal", h);
        animator.SetFloat("vertical", v);
    }

    void Shoot()
    {
        shooting = !shooting; // Switching between true and false
        animator.SetBool("shooting", shooting);
    }

}
