using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    [Header("Position Offsets")]
    [SerializeField] protected Vector3 xyz_offset =  new Vector3(0,12f,-6.5f);
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + xyz_offset;
    }
}
