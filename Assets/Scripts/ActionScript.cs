using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool magicAttack;

    [SerializeField]
    private float magicCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private FighterStats attackerStats;
    private FighterStats targetStats;
    private float damage = 0.0f;
    private float xMagicNewScale;
    private Vector2 magicScale;
    private GameObject battleMenu;

    private void Start()
    {
        magicScale = GameObject.Find("PlayerMagicFill").GetComponent<RectTransform>().localScale;
        battleMenu = GameObject.FindGameObjectWithTag("Menu");
    }

    public void Attack(GameObject victim)
    {
        this.battleMenu.SetActive(false);

        attackerStats = owner.GetComponent<FighterStats>();
        targetStats = victim.GetComponent<FighterStats>();

        if (attackerStats.magic >= magicCost || magicAttack == false)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);
            damage = multiplier * attackerStats.attack;

            if(magicAttack)
            {
                damage = multiplier * attackerStats.magic;
            }

            float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));
            owner.GetComponent<Animator>().Play(animationName);
            attackerStats.updateMagicFill(magicCost);
            StartCoroutine(targetStats.RecieveDamage(damage));

        } else
        {
            Invoke("SkipTurnContinueGame", 1); // <-- without this it freezes the game when the enemy tries magic without mana
        }
    }

    public void Block()
    {
        this.battleMenu.SetActive(false);

        attackerStats = owner.GetComponent<FighterStats>();
        owner.GetComponent<Animator>().Play(animationName);
        Invoke("targetStats.ContinueGame", 1);
    }

    void SkipTurnContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
        // You can add some kind animation indicating a failed spell in a possible final product.
    }
}
