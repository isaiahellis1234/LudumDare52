using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NpcScript : MonoBehaviour
{
    public Animation anim;

    public TextMeshPro textDeath;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.letLive)
        {
            GameManager.live = true;
            anim.Play("Live");
            StartCoroutine(RestartLevel());
        }
        if (GameManager.DeathSwitch)
        {
            textDeath.text = "Press Mouse To Harvest!";
        }

        if (Input.GetMouseButtonDown(0) && GameManager.DeathSwitch)
        {
            GameManager.die = true;
            anim.Play("Death");
            StartCoroutine(RestartLevel());
            //GameManager.DeathSwitch = false;
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1f);
        GameManager.letLive = false;
        GameManager.canvas = false;
        GameManager.nextCanvas = true;
        GameManager.DeathSwitch = false;
        Destroy(gameObject);
    }
}
