using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public int damage = 1;
    public float fireRate = 0.2f;
    public float fireRange = 20f;
    public Transform gunPoint;
    public Camera fpsCam;
    private float hitforce = 1000;

    private bool canShoot = true;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.2f);
    private LineRenderer line;
    private float nextFire;

	void Start ()
    {

        line = GetComponent<LineRenderer>();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire && canShoot)
        {
            nextFire = Time.time + fireRate;

            canShoot = false;

            StartCoroutine("Shot");

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            line.SetPosition(0, gunPoint.position);


            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, fireRange))
            {
                line.SetPosition(1, hit.point);
                EnemyHealth health = hit.collider.GetComponent<EnemyHealth>();

                if (health != null)
                {
                    health.Damage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitforce);
                }

            }
            else
            {
                line.SetPosition(1, rayOrigin + (fpsCam.transform.forward * fireRange));

            }
        }
	}

    IEnumerator Shot()
    {
        line.enabled = true;

        yield return shotDuration;

        canShoot = true;

        line.enabled= false;
    }
}
