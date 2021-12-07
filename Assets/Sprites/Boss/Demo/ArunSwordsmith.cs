using UnityEngine;
using System.Collections;

public class ArunSwordsmith : MonoBehaviour {

    [SerializeField] float      m_speed = 1.0f;
    [SerializeField] float      m_jumpForce = 2.0f;
    [SerializeField] bool       m_attackAnticipation = true;
    [SerializeField] bool       m_noBlood = false;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_ArunSwordsmith m_groundSensor;
    private bool                m_grounded = false;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_ArunSwordsmith>();
    }
	
	// Update is called once per frame
	void Update () {
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("e")) {
            m_animator.SetBool("noBlood", m_noBlood);
            m_animator.SetTrigger("Death");
        }
            
        //Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");

        //Attack
        else if(Input.GetMouseButtonDown(0)) {
            m_animator.SetBool("hasAttackAnticipation", m_attackAnticipation);
            m_animator.SetTrigger("Attack");
        }

        //Throw
        else if (Input.GetMouseButtonDown(1)) {
            m_animator.SetBool("hasAttackAnticipation", m_attackAnticipation);
            m_animator.SetTrigger("Throw");
        }

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }
}
