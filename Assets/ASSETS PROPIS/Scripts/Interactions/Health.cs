using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Image damageImage;

    [Range(0f, 1f)]
    public float[] damageAlphas;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        if (damageImage == null)
        {
            Debug.LogError("Fade Image is not assigned in the FadeController.");
        }

        else
        {
            //Ens assegurem que comenci sent transparent la imatge
            var c = damageImage.color;
            c.a = 0f;
            damageImage.color = c;
        }

        if(damageAlphas == null || damageAlphas.Length > maxHealth)
        {
            Debug.LogError("Damage alphas array is not assigned or empty.");
            
        } 
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        int hitsTaken = maxHealth - currentHealth;

        if(damageImage != null && damageAlphas != null && hitsTaken >0 && hitsTaken <= damageAlphas.Length)
        {
            float newAlpha = damageAlphas[hitsTaken - 1];
            SetImageAlpha(newAlpha);
        }

        if (currentHealth <= 0)
        {
            //Estarem morts
            currentHealth = 0;
            Die();
        }
    }

    private void SetImageAlpha(float alpha)
    {
        var c = damageImage.color;
        c.a = alpha;
        damageImage.color = c;
    }

    void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        //currentHealth += amount;

        //if (currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}
    }

    private void Die()
    {
        Debug.Log("Has mort");
        //reinicia l'escena actual
        //GameManager.Instance.RestartGame();

        //Canviar a escena Mort
        GameManager.Instance.GoToGameOver();
    }
}
