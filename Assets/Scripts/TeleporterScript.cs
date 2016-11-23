using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Room_2");
        }
    }

}
