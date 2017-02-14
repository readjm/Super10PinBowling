using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Pin>())
        {
            Destroy(collider.gameObject);
        }
    }
}
