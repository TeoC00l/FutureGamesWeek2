//@Author: Teodor Tysklind - Teodor.Tysklind@Futuregames.nu

using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private LinkedList<WallBehaviour> objectsInTrajectory;
    
    [SerializeField] private int damage = 10;
    [SerializeField] private AudioClip shootSound;
    private Animation gunAnimation;
    
    private void Start()
    {
        //Since neither the walls or shooter moves in this scenario, objects in trajectory only has to be calculated at start instead of at Shoot().
        UpdateTrajectory(Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity));
        gunAnimation = GetComponentInChildren<Animation>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }
    }
    
    private void Shoot()
    {
        if (gunAnimation.isPlaying)
        {
            return;
        }
        
        if (gunAnimation != null)
        {
            gunAnimation.Play();
        }

        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position, 1.0f);
        }
        
        int remainingDamage = damage;
        
        while (remainingDamage > 0 && objectsInTrajectory.Count > 0)
        {
            WallBehaviour current = objectsInTrajectory.First.Value;
            int hitPoints = current.CurrentHitPoints;
            
            if (hitPoints <= remainingDamage)
            {
                objectsInTrajectory.RemoveFirst();
            }
            
            current.CurrentHitPoints -= remainingDamage;
            remainingDamage -= hitPoints;
        }
    }

    private void UpdateTrajectory(RaycastHit[] hits)
    {
        objectsInTrajectory= new LinkedList<WallBehaviour>();
        Vector3 shooterPosition = transform.position;

        //Selection sort
        for (int i = 0; i < hits.Length; i++)
        {
            float smallestDistance = Vector3.Distance(shooterPosition, hits[i].transform.position);

            for (int j = i + 1; j < hits.Length; j++)
            {
                float currentObjectDistance = Vector3.Distance(shooterPosition, hits[j].transform.position);

                if (smallestDistance > currentObjectDistance)
                {
                    smallestDistance = currentObjectDistance;
                    RaycastHit cached = hits[i];
                    hits[i] = hits[j];
                    hits[j] = cached;
                }
            }
            
            //At the end of every iteration, add smallest object to sorted linked list.
            objectsInTrajectory.AddLast(hits[i].collider.gameObject.GetComponent<WallBehaviour>());
        }
    }
}    
