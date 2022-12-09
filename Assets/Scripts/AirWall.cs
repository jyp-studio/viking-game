using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWall : MonoBehaviour
{
    [SerializeField] GameObject ground;
    EnemySpawner tmp;

    private void Start()
    {
        tmp = GameObject.FindObjectOfType<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "viking")
        {
            for (int i = 0; i < 1; i++)
            {
                tmp.SpawnEnemy();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "viking")
        {
            Transform new_ground = Instantiate(ground.transform);
            new_ground.parent = other.transform.parent;
            Vector3 pos;
            float y = 4.5f;
            pos = new Vector3(0, y, 0);
            new_ground.localPosition = other.transform.localPosition + pos;
            Debug.Log($"new ground at {new_ground.localPosition}");
            Debug.Log(gameObject);
            Destroy(gameObject);
        }
    }
}
