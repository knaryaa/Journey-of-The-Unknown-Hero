using UnityEngine;
using System.Collections;

public class Sensor_Prototype : MonoBehaviour {

    private int m_ColCount = 0;

    private float m_DisableTimer;

    public GameObject[] item;
    public GameObject[] enemy;


    void Awake()
    {
        item = GameObject.FindGameObjectsWithTag("Item");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i <= item.Length - 1; i++)
        {
            item[i].GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(item[i].GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
        for (int i = 0; i <= enemy.Length - 1; i++)
        {
            enemy[i].GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(enemy[i].GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnEnable()
    {
        m_ColCount = 0;
    }

    public bool State()
    {
        if (m_DisableTimer > 0)
            return false;
        return m_ColCount > 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        m_ColCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        m_ColCount--;
    }

    void Update()
    {
        m_DisableTimer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        m_DisableTimer = duration;
    }
}
