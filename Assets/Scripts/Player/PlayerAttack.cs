using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    PlayerBulletPool bulletPool;

    void Start()
    {
        bulletPool = GameObject.Find("PlayerBulletPool").GetComponent<PlayerBulletPool>();
    }
    
    public void Fire(InputAction.CallbackContext context)
    {
        bulletPool.Next();
    }
}
