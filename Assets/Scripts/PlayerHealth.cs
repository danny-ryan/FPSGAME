using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider hp;
    public float health = 100;

	void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Enemy_Bullet")
        {
            health -= 1;
            
        }
	}
	
	void Update ()
    {
        hp.value = health;

        if (health <= 0)
        {
            SceneManager.LoadScene("Scene1");
        }
	}
}
