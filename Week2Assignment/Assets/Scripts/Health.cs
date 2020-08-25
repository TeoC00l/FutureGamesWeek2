using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int healthPoints = 10;
    public int HealthPoints { set { healthPoints = value; } get { return healthPoints; } }

    void Start()
    {
        
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }


}
