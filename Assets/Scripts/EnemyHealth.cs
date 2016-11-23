using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float health = 4;

	void Update ()
    {
	}

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        health -= damageAmount;

        //Check if health has fallen below zero
        if (health <= 0)
        {
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive(false);
        }
    }

}
