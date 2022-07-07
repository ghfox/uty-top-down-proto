using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = new(0, 0, 0);
        transform.rotation = player.GetComponent<PlayerLook>().lookRotation;
        transform.position = player.transform.position + (0.5f * player.transform.position.normalized);
        transform.position = new(transform.position.x, 0, transform.position.z);
        GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
        Invoke("Disable", 1f);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}

