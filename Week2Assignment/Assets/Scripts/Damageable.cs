using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 10;
    public int CurrentHitPoints { get; set; }
    protected AudioClip onDeathSound;

    private void Awake()
    {
        CurrentHitPoints = maxHitPoints;
    }

    private void Update()
    {
        if(CurrentHitPoints <= 0)
        {
            Die();
        }
    }
    

    private void Die()
    {
        if (onDeathSound != null)
        {
            AudioSource.PlayClipAtPoint(onDeathSound, transform.position);
        }
        
        Destroy(gameObject);
    }
}
