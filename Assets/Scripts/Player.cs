using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;
    public int height;
    public int Score;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * height;
            thisAnimation.Play();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "lose")
        {
            SceneManager.LoadScene("gamelose");
        }

        if (other.gameObject.tag == "Score")
        {
            Score++;
            Destroy(other.gameObject);
        }
    }
}
