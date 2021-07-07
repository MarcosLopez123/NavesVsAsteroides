using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class MovimientoNave : MonoBehaviour
{

    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;

    [Header("Disparo")]
    public GameObject shot;
    public Transform DisparoD;
    public Transform DisparoI;

    public float fireRate;
    private float nextFire;

    private AudioSource audioSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        float DireccionX = CrossPlatformInputManager.GetAxis("Horizontal");
        float DireccionZ = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(DireccionX, 0f, DireccionZ);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
      //  rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -tilt);


        if (CrossPlatformInputManager.GetButtonDown("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, DisparoD.position, Quaternion.identity);
            Instantiate(shot, DisparoI.position, Quaternion.identity);
            audioSource.Play();


        }
    }
}
