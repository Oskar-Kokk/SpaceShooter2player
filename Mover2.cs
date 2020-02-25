using UnityEngine;
using System.Collections;

public class Mover2 : MonoBehaviour
{
    public float speed;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
