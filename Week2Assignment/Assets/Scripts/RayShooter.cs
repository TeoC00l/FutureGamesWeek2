using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private RaycastHit[] hits;
    private bool fired = false;
    [SerializeField] private int damage = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }
    private void Shoot()
    {
        Debug.Log("Shots fired");
        hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity);

        for(int i = 0; i < hits.Length; i++)
        {
            Debug.Log("A hit!");
        }
    }

    private void sortByDistance()
    {

    }
}
