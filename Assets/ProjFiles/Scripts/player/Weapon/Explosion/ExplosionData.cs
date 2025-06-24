using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionData", menuName = "Scriptable Objects/ExplosionData")]
public class ExplosionData : ScriptableObject
{
    public GameObject[] explosionsList = new GameObject[1];
}
