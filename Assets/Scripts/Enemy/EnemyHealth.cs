using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class EnemyHealth : MonoBehaviour
{
    [HideInInspector] public float currentHealth;
    Animator anim;
    public float maxHealth = 100f;
    [SerializeField] private Image EnemyHealthBar;
    private SphereCollider targetCollider;
    public int ExpAmount = 10;
    public static event Action<int> onDeath;
    private void Awake()
    {
        targetCollider = GetComponentInChildren<SphereCollider>();
        anim = GetComponent<Animator>();
        if (this.gameObject.tag == "Boss")
        {
            maxHealth = UnityEngine.Random.Range(100, 120);
        }
        else if (this.gameObject.tag == "Enemy")
        {
            maxHealth = UnityEngine.Random.Range(40, 60);
        }
        currentHealth = maxHealth;

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        EnemyHealthBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth > 0)
        {
            if (this.gameObject.tag == "Boss")
            {
                AudioManager.instance.PlaySfx(6);
            }
            else if (this.gameObject.tag == "Enemy")
            {
                AudioManager.instance.PlaySfx(3);
            }
            anim.SetTrigger("Hit");
        }
        if (currentHealth <= 0)
        {
            if(this.gameObject.tag == "Boss")
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Animator>().SetTrigger("win");
                
                AudioManager.instance.PlayVictoryGameMusic();
            }

            onDeath(ExpAmount);
            if (targetCollider.gameObject.activeInHierarchy)
            {
                targetCollider.gameObject.SetActive(false);
            }
        
        }
    }


}
