using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public SpriteRenderer healthBarRenderer;
    public Sprite[] healthSprites;

    public float invincibilityDuration = 1f;
    private bool isInvincible;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage called, amount: " + amount + " current health before: " + currentHealth + " isInvincible: " + isInvincible);
        if (isInvincible) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            StartCoroutine(InvincibilityFlash());
        }
    }

    void UpdateHealthBar()
    {
        Debug.Log("Updating health bar, health: " + currentHealth);
        healthBarRenderer.sprite = healthSprites[currentHealth];
    }

    private System.Collections.IEnumerator InvincibilityFlash()
    {
        Debug.Log("Invincibility flash STARTED");
        isInvincible = true;
        SpriteRenderer dinoRenderer = GetComponent<SpriteRenderer>();

        float elapsed = 0f;
        while (elapsed < invincibilityDuration)
        {
            dinoRenderer.enabled = !dinoRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }

        dinoRenderer.enabled = true;
        isInvincible = false;
        Debug.Log("Invincibility flash ENDED, isInvincible now: " + isInvincible);
    }
}