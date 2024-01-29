using TMPro;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] int startHealth = 10;
    [SerializeField] TMP_Text uiText;
    [SerializeField] MenuManager mm;
    

    int currentHealth;

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Start()
    {

        currentHealth = startHealth;
        UpdUIText();
    }

    public void Damage(int damage)
    {
        if (currentHealth <= 0) return;
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        if (currentHealth <= 0)
        {
            mm.OnGameEnded();
            this.gameObject.SetActive(false);
            
        }

        UpdUIText();
    }

    void UpdUIText()
    {
        uiText.text = "Health: " + currentHealth.ToString();
    }

}