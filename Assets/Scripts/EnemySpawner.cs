using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public List<GameObject> enemy_list = new List<GameObject>();

    public void SpawnEnemy()
    {
        enemy_list.Add(enemy);
        Transform c = Instantiate(enemy.transform);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        c.parent = player.transform.parent;

        Vector3 pos;
        float x; float z;
        x = Random.Range(-10, 10); z = Random.Range(-10, 10);
        pos = new Vector3(x, 1, z);

        c.localPosition = player.transform.localPosition + pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        // SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
