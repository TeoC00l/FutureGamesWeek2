using UnityEngine;

public class WallBehaviour : Damageable
{
    [SerializeField]private Wall typeOfWall;

    private void Start()
    {
        if (typeOfWall == null)
        {
            typeOfWall =Resources.Load("Scriptable Objects/WoodWall") as Wall;
        }
        
        GetComponent<Renderer>().material = typeOfWall.material;
        CurrentHitPoints = typeOfWall.hitPoints;
        onDeathSound = typeOfWall.onDeathSound;
    }
}
