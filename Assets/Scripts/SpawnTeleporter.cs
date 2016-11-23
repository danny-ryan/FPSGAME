using UnityEngine;
using System.Collections;

public class SpawnTeleporter : MonoBehaviour
{
    public GameObject teleporter;
    
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            teleporter.SetActive(true);
        }
    }                                 
}
