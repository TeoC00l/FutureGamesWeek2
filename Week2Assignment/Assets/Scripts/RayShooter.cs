using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private WallBehaviour[] sortedWalls;
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
        int remainingDamage = damage;

        sortByDistance(Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity));

        while (remainingDamage > 0 && sortedWalls.Length > 0)
        {
            Debug.Log("yes");
            int hitPoints = sortedWalls[0].CurrentHitPoints;

            if (remainingDamage >= hitPoints)
            {
                sortedWalls[0].CurrentHitPoints = 0;
                removeFirstIndex();
            }
            else
            {
                sortedWalls[0].CurrentHitPoints -= remainingDamage;
            }

            remainingDamage -= hitPoints;
        }
    }

    private void sortByDistance(RaycastHit[] hits)
    {
        if (hits.Length == 0)
        {
            return;
        }

        sortedWalls = new WallBehaviour[hits.Length];

        //Selection sort
        for (int i = 0; i < hits.Length; i++)
        {
            float smallestDistance = Vector3.Distance(transform.position, hits[i].transform.position);
            sortedWalls[i] = sortedWalls[i] = hits[i].collider.gameObject.GetComponent<WallBehaviour>();

            for (int j = i+1; j < hits.Length; j++)
            {
                float currentObjectDistance = Vector3.Distance(transform.position, hits[j].transform.position);

                if (smallestDistance > currentObjectDistance)
                {
                    smallestDistance = currentObjectDistance;
                    sortedWalls[i] = hits[j].collider.gameObject.GetComponent<WallBehaviour>();
                }
            }
        }
    }

    private void removeFirstIndex()
    {
        WallBehaviour[] newArray = new WallBehaviour[sortedWalls.Length-1];

        for (int i = 1; i <= sortedWalls.Length; i++)
        {
            newArray[i-1] = sortedWalls[i];
        }

        sortedWalls = newArray;
    }
}
