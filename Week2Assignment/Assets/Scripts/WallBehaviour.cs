using System.Dynamic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    [SerializeField]private Wall typeOfWall;
    private int currentHitPoints;
    AudioSource audioSource;
    public int CurrentHitPoints { set { currentHitPoints = value; } get { return currentHitPoints; } }


    void Start()
    {
        //TODO set wall to wood if null;
        GetComponent<Renderer>().material = typeOfWall.material;
        audioSource = FindObjectOfType<AudioSource>();
        currentHitPoints = typeOfWall.hitPoints;
    }

    void Update()
    {
        if(CurrentHitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        audioSource.PlayOneShot(typeOfWall.onDeathSound);
        Destroy(gameObject);
    }
}
