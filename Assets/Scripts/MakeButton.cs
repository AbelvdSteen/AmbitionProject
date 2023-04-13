using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;
    private GameObject player;
    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("btnFight") == 0)
        {
            player.GetComponent<FighterAction>().SelectAttack("melee");
        }
        else if (btn.CompareTo("btnMagic") == 0)
        {
            player.GetComponent<FighterAction>().SelectAttack("magic");
        }
        else if (btn.CompareTo("btnBlock") == 0)
        {
            player.GetComponent<FighterAction>().SelectAttack("block");
        }
        else
        {
            player.GetComponent<FighterAction>().SelectAttack("run");
        }
    }
}
