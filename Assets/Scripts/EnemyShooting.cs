using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public Transform target;
    public GameObject bullet;
    public float bulletSpeed = 0;
    public Transform bulletPos;

    public float attackDistance = 15f;

    bool canShoot = true;

    void Start()
    {
    }
    //void OnTriggerStay(Collider col)
   // {
   void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        transform.LookAt(target);

        if (dist < attackDistance && canShoot)
        {

            GameObject bulletClone = Instantiate(bullet, bulletPos.position, transform.rotation) as GameObject;

            bulletClone.GetComponent<Rigidbody>().AddForce(bulletClone.transform.forward * bulletSpeed, ForceMode.Impulse);

            Destroy(bulletClone, 1.5f);

            canShoot = false;

            StartCoroutine("waitPls");
        }

    }

    IEnumerator waitPls()
    {
        yield return new WaitForSeconds(0.5f);

        canShoot = true;
    }
}
