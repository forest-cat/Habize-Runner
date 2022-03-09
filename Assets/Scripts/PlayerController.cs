using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    //Building and importing some things
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    private enum State {idle, run, jump, falling, hurt};
    private State state = State.idle;
    private bool moveLeft;
    private bool moveRight;
    private float oldPosition = 0;
    private float time = 0.05f;
    private float timer = 2;
    private GameObject leftButton;
    private GameObject rightButton;
    private GameObject jumpButtonn;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private LayerMask Zone;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jump = 15f;
    private int counter_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        
        


        moveLeft = false;
        moveRight = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (coll.IsTouchingLayers(Zone))
        {
            PlayerPrefs.SetString("isDead", "true");
            PlayerPrefs.Save();
            Destroy(gameObject);
            GetComponent<PlayerController>().enabled = false;
        }
        
        Movement();

        VelocityCheck();
        anim.SetInteger("Player_State", (int)state);
        timer += Time.deltaTime;
        if(transform.position.y < -12 && SceneManager.GetActiveScene().name == "Singleplayer")
        {

            SceneManager.LoadScene("MainMenu");

        }
        if (SceneManager.GetActiveScene().name == "Multiplayer" && transform.position.y < -12)
        {

            PlayerPrefs.SetString("isDead", "true");
            PlayerPrefs.Save();
            Destroy(gameObject);
            GetComponent<PlayerController>().enabled = false;
        }
        
        leftButton = GameObject.Find("Left");
        rightButton = GameObject.Find("Right");
        jumpButtonn = GameObject.Find("Jump");
        if (SceneManager.GetActiveScene().name == "Multiplayer" && counter_num == 0)
        {
            EventTrigger trigger_left_down = leftButton.GetComponent<EventTrigger>();
            EventTrigger.Entry entry_left_down = new EventTrigger.Entry();
            entry_left_down.eventID = EventTriggerType.PointerDown;
            entry_left_down.callback = new EventTrigger.TriggerEvent();
            UnityAction<BaseEventData> l_callback_left_down = new UnityAction<BaseEventData>(leftButtonDown);
            entry_left_down.callback.AddListener(l_callback_left_down);
            trigger_left_down.triggers.Add(entry_left_down);

            EventTrigger trigger_left_up = leftButton.GetComponent<EventTrigger>();
            EventTrigger.Entry entry_left_up = new EventTrigger.Entry();
            entry_left_up.eventID = EventTriggerType.PointerUp;
            entry_left_up.callback = new EventTrigger.TriggerEvent();
            UnityAction<BaseEventData> l_callback_left_up = new UnityAction<BaseEventData>(leftButtonUp);
            entry_left_up.callback.AddListener(l_callback_left_up);
            trigger_left_up.triggers.Add(entry_left_up);

            EventTrigger trigger_right_down = rightButton.GetComponent<EventTrigger>();
            EventTrigger.Entry entry_right_down = new EventTrigger.Entry();
            entry_right_down.eventID = EventTriggerType.PointerDown;
            entry_right_down.callback = new EventTrigger.TriggerEvent();
            UnityAction<BaseEventData> l_callback_right_down = new UnityAction<BaseEventData>(rightButtonDown);
            entry_right_down.callback.AddListener(l_callback_right_down);
            trigger_right_down.triggers.Add(entry_right_down);

            EventTrigger trigger_right_up = rightButton.GetComponent<EventTrigger>();
            EventTrigger.Entry entry_right_up = new EventTrigger.Entry();
            entry_right_up.eventID = EventTriggerType.PointerUp;
            entry_right_up.callback = new EventTrigger.TriggerEvent();
            UnityAction<BaseEventData> l_callback_right_up = new UnityAction<BaseEventData>(rightButtonUp);
            entry_right_up.callback.AddListener(l_callback_right_up);
            trigger_right_down.triggers.Add(entry_right_up);

            EventTrigger trigger_jump_down = jumpButtonn.GetComponent<EventTrigger>();
            EventTrigger.Entry entry_jump_down = new EventTrigger.Entry();
            entry_jump_down.eventID = EventTriggerType.PointerDown;
            entry_jump_down.callback = new EventTrigger.TriggerEvent();
            UnityAction<BaseEventData> l_callback_jump_down = new UnityAction<BaseEventData>(jumpButtonDown);
            entry_jump_down.callback.AddListener(l_callback_jump_down);
            trigger_jump_down.triggers.Add(entry_jump_down);



            counter_num++;
        }
        oldPosition = transform.position.x;
        //Debug.Log((int)state);
    }

    private void Movement()
    {
        var movement = Input.GetAxis("Horizontal");
        if (movement > 0 || moveRight)
        {
            state = State.run;
            //Flips the Player into the direction he is walking
            transform.localScale = new Vector2(1, 1);
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else if (movement < 0 || moveLeft)
        {
            state = State.run;
            //Flips the Player into the direction he is walking
            transform.localScale = new Vector2(-1, 1);
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }

        

        if (Input.GetButtonDown("Jump"))
        {
            jumpButton();
        }
    }

    private void VelocityCheck()
    {
        if (oldPosition != transform.position.x)
        {
            state = State.run;
        }
        else if (oldPosition == transform.position.x)
        {
            state = State.idle;
        }
    }


    //Button Down Press Funkctions
    public void leftButtonDown(BaseEventData eventData)
    {
        moveLeft = true;
    }
    public void rightButtonDown(BaseEventData eventData)
    {
        moveRight = true;
    }
    public void jumpButtonDown(BaseEventData eventData)
    {
        if (timer >= time)
        {
            jumpButton();
            timer = 0;
        }
    }

    //Button Release Functions
    public void leftButtonUp(BaseEventData eventData)
    {
        moveLeft = false;
    }
    public void rightButtonUp(BaseEventData eventData)
    {
        moveRight = false;
    }
    public void jumpButtonUp()
    {
        
    }

    //This Function is executed when pressing spacebar or using the jump Button
    public void jumpButton()
    {
        if (coll.IsTouchingLayers(Ground))
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            state = State.jump;
        }
        
    }
    
}
