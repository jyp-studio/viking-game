using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGroundTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exit groundTile");
        if (other.transform.name == "viking")
        {
            Destroy(gameObject);
        }

    }
}
