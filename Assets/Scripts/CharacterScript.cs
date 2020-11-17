using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public GameObject healthText;
    public float speed = 10;
    public float rotatespeed = 20;
    public float damageRate = 5;
    public float health = 100;

    Animator Animator;
    Rigidbody PlayerRb;
    bool onGround;
    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        healthText.GetComponent<Text>().text = "Health :" + health;
    }

    // Update is called once per frame
    void Update()
    {

        if (alive == true)
        {
            //Forward Moving

            if (Input.GetKeyDown(KeyCode.W))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Animator.SetBool("moving", true);
            }


            if (Input.GetKeyUp(KeyCode.W))
            {
                Animator.SetBool("moving", false);
            }

            //Left Moving

            if (Input.GetKeyDown(KeyCode.A))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 270, 0);
                Animator.SetBool("moving", true);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                Animator.SetBool("moving", false);
            }

            //Backward Moving

            if (Input.GetKeyDown(KeyCode.S))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                Animator.SetBool("moving", true);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                Animator.SetBool("moving", false);
            }

            //Right Moving

            if (Input.GetKeyDown(KeyCode.D))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                Animator.SetBool("moving", true);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                Animator.SetBool("moving", false);
            }

            //Attack

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Animator.SetTrigger("attack");

            }



        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire" && alive == true)
        {
            health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = "Health :" + health;

            if (health <= 0)
            {
                Animator.SetTrigger("death");
                alive = false;
                healthText.GetComponent<Text>().text = "Health : 0";
            }

        }
    }

}
