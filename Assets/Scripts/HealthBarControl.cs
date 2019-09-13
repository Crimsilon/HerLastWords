using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarControl : MonoBehaviour
{
    // Start is called before the first frame update

    private characterStats stats;
    public GameObject healthBar;

    void Start()
    {
        stats = gameObject.GetComponent<characterStats>();
    }



    public void setHealthBar(float HubHealth)
    {
        //hubHealth needs to be between 0 and 1 , calculated by max and cur helth
        print(HubHealth);
        healthBar.transform.localScale = new Vector3(HubHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {



       



    }
}
