using UnityEngine;
using System.Collections;

public class DoorActivatorScript : MonoBehaviour
{
    private Animator anim;
    private bool open;

    void Start()
    {
        open = false;
        anim = GetComponent<Animator>();
    }

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("Open", true);
        }
    }
    void OnTriggerExit()
    {
        anim.SetBool("Open", false);
    }
}
