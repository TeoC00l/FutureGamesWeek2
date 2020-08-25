using UnityEngine;

[CreateAssetMenu (fileName = "New Wall", menuName ="Wall")]
public class Wall : ScriptableObject
{
    public int hitPoints;
    public AudioClip onDeathSound;
    public Material material;
}
