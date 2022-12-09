using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;
    Rigidbody rb;
    Animator animator;
    [SerializeField] float movingSpeed = 10f;
    [SerializeField] float JumpForce = 10f;

    int numCoin = 0;
    bool run = false;
    bool attack = false;
    public int SceneIndexDestination = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        run = false;
        attack = false;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movingSpeed += 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movingSpeed -= 10f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
            run = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
            run = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
            run = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attack = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject coin = GameObject.FindGameObjectWithTag("Coin");
            float dist = Vector3.Distance(coin.transform.localPosition, gameObject.transform.localPosition);
            if (dist < 5)
            {
                Destroy(coin);
                numCoin++;
                // GameObject coins = GameObject.FindGameObjectWithTag("CoinCounter");
                // coins.transform = numCoin;
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            // get current scene
            Scene scene = SceneManager.GetActiveScene();
            print("clicking scene");

            // load a new scene 
            SceneManager.LoadScene(SceneIndexDestination);
        }
        animator.SetBool("Run", run);
        animator.SetBool("Attack", attack);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
                rb.AddForce(JumpForce * Vector3.up);
            }
        }
    }
}
