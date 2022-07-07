using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
    PlayerBullet[] bullets;
    int cursor = 0;
    
    void Start()
    {
        bullets = GetComponentsInChildren<PlayerBullet>(true);
        Debug.Log(bullets.Length);
    }
    
    public void Next()
    {
        bullets[cursor].gameObject.SetActive(true);
        cursor++;
        if (cursor >= bullets.Length)
            cursor = 0;
    }
}
