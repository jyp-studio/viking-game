using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject coin;
    bool attack = false, run = false;
    // private float _projectileSpeed = 100f;
    int coolDown = 0;
    int maxCoolTime = 0;
    int hp = 0;
    Animator animator;
    void Start()
    {
        hp = 2;
        animator = GetComponent<Animator>();
        maxCoolTime = Random.Range(3, 8) * 1000;
    }
    void Update()
    {
        attack = false;
        run = false;
        coolDown--;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dist = Vector3.Distance(player.transform.localPosition, gameObject.transform.localPosition);
        if (dist > 100)
        {
            Debug.Log($"des:{gameObject}");
            Destroy(gameObject);
        }
        if (dist < 8 && hp > 0)
        {
            run = true;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                                                                player.transform.position,
                                                              0.01f);
        }
        if (dist < 3 && coolDown <= 0 && hp > 0)
        {
            attack = true;
            coolDown = maxCoolTime;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (dist < 3 && hp > 0)
            {
                hp--;
                GameObject hp_bar = GameObject.FindGameObjectWithTag("HP");
                hp_bar.transform.localScale -= new Vector3(1.5f, 0, 0);
                if (hp <= 0)
                {

                    Destroy(hp_bar);
                    gameObject.transform.Rotate(0, 0, 45);

                    Transform c = Instantiate(coin.transform);
                    c.parent = transform;
                    Vector3 pos;
                    float y = 4.5f;
                    pos = new Vector3(0, y, 0);
                    c.position = gameObject.transform.position;
                }
            }
        }
        animator.SetBool("Attack", attack);
        animator.SetBool("Run", run);
    }
}
