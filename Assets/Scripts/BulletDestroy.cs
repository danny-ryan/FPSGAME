using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player") 
        {
            Destroy(this.gameObject);
        }
    }
	
}

