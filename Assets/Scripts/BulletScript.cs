using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float lifeTime = 5f;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, lifeTime);
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
