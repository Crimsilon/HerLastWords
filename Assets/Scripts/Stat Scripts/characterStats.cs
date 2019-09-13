using UnityEngine;

public class characterStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth { get; private set; }

    public stat damage;
    public stat armor;

    public float hpRemain;

    private void Awake()
    {
        currentHealth = maxHealth;

        print("max" + maxHealth + "cur" + currentHealth);
    }






    //Debug to test received damage
    private void Update ()
    {

        

    }
    
    
    public void TakeDamage (int damage)
    {
        //prevents some damage depending on armor stats
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

      
        currentHealth -= damage;
        print(currentHealth + " " + maxHealth);

        hpRemain =  (float)currentHealth / maxHealth;

        print(hpRemain);
        gameObject.GetComponent<HealthBarControl>().setHealthBar(hpRemain);
        Debug.Log(transform.name + " takes " + damage + " damage ");

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public virtual void Die ()
    {
        //Death happens
        Debug.Log(transform.name + " died ");

        

    }
}
