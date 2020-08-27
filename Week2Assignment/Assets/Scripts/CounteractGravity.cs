//@Author: Teodor Tysklind - Teodor.Tysklind@Futuregames.nu

using UnityEngine;

public class CounteractGravity : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 gravitationalVelocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //gravitational velocity is fetched every frame in case some funny guy tries to change it in runtime.
        gravitationalVelocity = Physics.gravity;
        rigidbody.AddForce(-gravitationalVelocity * rigidbody.mass);
    }
}
