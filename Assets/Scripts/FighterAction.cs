using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;

    [SerializeField]
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject magicPrefab;

    [SerializeField]
    private GameObject block;

    private GameObject currentAttack;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    public void SelectAttack(string btn)
    {
        GameObject victim = player;
        if (tag == "Player")
        {
            victim = enemy;
        }
        if (btn.CompareTo("melee") == 0)
        {
            meleePrefab.GetComponent<ActionScript>().Attack(victim);
        } else if (btn.CompareTo("magic") == 0)
        {
            magicPrefab.GetComponent<ActionScript>().Attack(victim);
        } else if (btn.CompareTo("block") == 0)
        {
            block.GetComponent<ActionScript>().Block();
        } else
        {
            Debug.Log("Run!");
        }
    }
}