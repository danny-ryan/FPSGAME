using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private bool firin = false;
    public AudioClip aud;

    private bool canShoot;

    public GameObject particle_1;
    public GameObject particle_2;

    AudioSource audsource;
    

	void Start ()
    {
        canShoot = true;
        audsource = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
     
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            firin = true;
            canShoot = false;

            StartCoroutine("wait");

            particle_1.SetActive(true);
            particle_2.SetActive(true);

            if (firin && !audsource.isPlaying)
            {
                audsource.PlayOneShot(aud);
                audsource.loop = true;
            }
        }
        else
        {
            particle_1.SetActive(false);
            particle_2.SetActive(false);
        }

        if (!firin)
        {
            audsource.Stop();
        }
	}
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);

        canShoot = true;

        firin = false;

    }
}
