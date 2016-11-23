using UnityEngine;
using System.Collections;

public class DeathScritpt : MonoBehaviour
{
    private GameObject Enemy;

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

	void OnCollisionEnter()
    {
        Destroy(Enemy);
     
    }
}
