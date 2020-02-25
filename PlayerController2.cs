using UnityEngine;
using System.Collections;

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController2 : MonoBehaviour
{
    public float speed2;
    public float tilt2;
    public Boundary boundary;

    public GameObject shot2;
    public Transform shotSpawn2;
    public float fireRate2;

    private float nextFire2;

    public AudioSource playerSound2;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time > nextFire2)
        {
            nextFire2 = Time.time + fireRate2;
            GameObject clone =
            Instantiate(shot2, shotSpawn2.position, shot2.transform.rotation); // as GameObject;
            playerSound2.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal2 = Input.GetAxis("Horizontal2");
        float moveVertical2 = Input.GetAxis("Vertical2");

        Vector3 movement = new Vector3(moveHorizontal2, 0.0f, moveVertical2);
        GetComponent<Rigidbody>().velocity = movement * speed2;

        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt2);
    }
}
