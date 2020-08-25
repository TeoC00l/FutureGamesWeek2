//@Author: Teodor Tysklind - Teodor.Tysklind@Futuregames.nu
using UnityEngine;

public class CounteractGravity : MonoBehaviour
{
    float yPosition;

    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}
