using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    Animation anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.DeathSwitch && GameManager.health > 0)
        {
            anim.Play("Attack");
            //GameManager.DeathSwitch = false;
        }
    }
}
