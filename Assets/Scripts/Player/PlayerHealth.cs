using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public float currentHealth;
    public float maxHealth = 100f;
    private bool isShielded;
    public bool Shielded { get { return isShielded; } set { isShielded = value; } }

    private Animator anim;

    private Image healtImage;

    public GameObject gameOverText;
    private GameObject canvas;

    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        healtImage = GameObject.Find("HealthOrb").GetComponent<Image>();
        canvas = GameObject.Find("Canvas");
    }
    public void TakeDamage(float amount)
    {
        if (!isShielded)
        {
            currentHealth -= amount;

            UpdateHealth();

            if (currentHealth <= 0f)
            {
                anim.SetBool("Death",true);
                GetComponent<CharacterController>().enabled = false;
                GameObject gameOver = Instantiate(gameOverText);
                gameOver.transform.SetParent(canvas.transform);
                gameOver.transform.localPosition = Vector3.zero;
            }
        }
    }
    public void HealPlayer(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        healtImage.fillAmount = currentHealth / maxHealth;
    }
 
}
