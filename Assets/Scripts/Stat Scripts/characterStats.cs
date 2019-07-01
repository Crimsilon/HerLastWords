using UnityEngine;

public class characterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }



    public stat damage;
    public stat armor;


    private void Awake()
    {
        currentHealth = maxHealth;
    }






    //Debug to test received damage
    private void Update ()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);

        }

    }
    
    
    public void TakeDamage (int damage)
    {
        //prevents some damage depending on armor stats
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        currentHealth -= damage;
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
