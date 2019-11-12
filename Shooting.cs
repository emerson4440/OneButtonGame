using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject m_Bullet;

    public float m_Projectileforce = 10;
    public float m_Addforce;
    public float m_Timer = 0;
    public float m_CDtimer;
    public float m_Maxforce = 15f;

    public static float m_Charge;

    public bool m_StartTimer;

    private Player m_Script;

    [SerializeField] private Image m_ChargeBar;

    [SerializeField] private TMP_Text m_uiText;
    [SerializeField] private float m_CooldownTimer;

    // Start is called before the first frame update 
    void Start()
    {
        m_Script = GameObject.Find("Arrow").GetComponent<Player>();
        m_StartTimer = false;
        m_CDtimer = m_CooldownTimer;
        //m_ChargeBar = GetComponent<Image>();
        m_Charge = m_Maxforce;
        m_Timer = 0;
    }

    // Update is called once per frame 
    void Update()
    {
        Timer();
        m_ChargeBar.fillAmount = m_Addforce / 25;

        if (m_Timer == 0 && Input.GetKey("space"))
        {
            m_Script.m_Pause = true; 
            m_Addforce += 0.15f;

            if (m_Addforce >= 25)
            {
                
                m_Addforce = 25;
            }
        }
        if (m_Timer == 0 && Input.GetKeyUp("space"))
        {
            m_Script.m_Pause = false;
            GameObject projectile = Instantiate(m_Bullet, transform.position, transform.parent.rotation) as GameObject;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = projectile.transform.right * m_Addforce;
            m_StartTimer = true;
            m_Timer = 1.5f;
            m_Addforce = 0;
        }

    }

    private void Timer()
    {
        if (m_StartTimer == true)
        {
            m_Timer -= Time.deltaTime;
            m_uiText.text = m_Timer.ToString("F");
            if (m_Timer <= 0.0f)
            {
                m_uiText.text = "0.0";
                m_Timer = 0.0f;
                m_StartTimer = false;
            }
        }
    }
}
