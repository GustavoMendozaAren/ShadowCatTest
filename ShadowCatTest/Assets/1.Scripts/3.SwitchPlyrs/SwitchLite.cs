using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLite : MonoBehaviour
{
    //Players Array
    public GameObject[] players; 
    private int currentPlayerIndex = 0; 
    public GameObject RevolverBullet;

    //CheckIfOnGround
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private Rigidbody2D rb;

    public Animator[] Anim;

    //Jump
    float jumpPower;
    float jump2Power;
    private bool isOnGround;
    private bool hasJumped;
    private bool hasdoubleJumped;
    private bool doubleJump;

    //Walk
    float speed = 5f;
    private float h;


    //Shoot
    public GameObject gunImage;
    public GameObject[] Balas;
    int BalasIndex = 0;

    public GameObject BalasJugador1;


    //Script
    public PlayerDamage PDS;

    //Dash
    private bool canDash = true;
    float dashVelocity = 3.5f;
    float dashTime = 0.1f;
    float dashWait = 0.1f;

    //Joysrtick
    public Joystick joystick;

    //ButtonsActions
    bool ShootBttn = false;
    bool JumpBttn = false;
    bool RunBttn = false;
    bool doubleJumpBttn = false;
    bool dashBttn = false;

    //ButtonsSwhitch
    public GameObject BttnsDetective, BttnsCat;
    public GameObject BtnJmpCat, BtnDblCat;

    //Music
    private MusicBehaviour musicBehaviour;
    float transformMusicValue = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject estadoDetective = GameObject.Find("Music");
        musicBehaviour = estadoDetective.GetComponent<MusicBehaviour>();
        for (int i = 0; i < players.Length; i++)
        {
            if (i == currentPlayerIndex)
            {
                players[i].SetActive(true);
            }
            else
            {
                players[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        //SwitchPlayers();
        SwitchButtons();
        ShootAnim();
        CheckIfOnGround();
        //PlayerJump();
        Player1Stats();
        DeadAnimation();
    }

    void FixedUpdate()
    {
        PlayerWalk();
        PlayerJump();

    }

    public void SwitchPlayers()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        players[currentPlayerIndex].SetActive(false);


        currentPlayerIndex++;
        if (currentPlayerIndex >= players.Length)
        {
            currentPlayerIndex = 0;
            transformMusicValue = 0f;
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.detectiveSong, this.transform.position);
        }
        else
        {
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.catSong, this.transform.position);
            transformMusicValue = 1f;
        }

        players[currentPlayerIndex].SetActive(true);
        Anim[currentPlayerIndex].SetTrigger("Puff");
        AudioManager.instance.PlayOneShot(FMODEvents.instance.transformFX, this.transform.position);
 
        musicBehaviour.estadoTransform = transformMusicValue;
        //}
    }

    private void SwitchButtons()
    {
        if(currentPlayerIndex == 0)
        {
            BttnsDetective.SetActive(true);
            BttnsCat.SetActive(false);
        }
        if (currentPlayerIndex == 1)
        {
            BttnsDetective.SetActive(false);
            BttnsCat.SetActive(true);
        }
    }

    void PlayerWalk()
    {
        //h = Input.GetAxisRaw("Horizontal");
        h = 0;

        //if (h > 0)
        if (joystick.Horizontal > 0)
        {
            h = 1f;
            //AnimationIntParameters("Speed");
            //rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);

            ChangeDirection(1);
            Anim[0].SetBool("Run", false);
            if (currentPlayerIndex == 0 && (Input.GetKey(KeyCode.LeftShift)|| RunBttn))
            {
                Anim[0].SetBool("Run", true);
                //rb.velocity = new Vector2(speed *1.5f, rb.velocity.y);
                transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);
            }
            //Dash
            if ((dashBttn || Input.GetKeyDown(KeyCode.LeftShift)) && canDash && currentPlayerIndex == 1)
            {
                StartCoroutine(Dash());
            }
        }   //if (h < 0)
        else if (joystick.Horizontal < 0)
        {
            h = -1f;
            //AnimationIntParameters("Speed");
            //rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);

            ChangeDirection(-1);
            Anim[0].SetBool("Run", false);
            if (currentPlayerIndex == 0 && (Input.GetKey(KeyCode.LeftShift)|| RunBttn))
            {
                Anim[0].SetBool("Run", true);
                //rb.velocity = new Vector2(-speed * 1.5f, rb.velocity.y);
                transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);
            }
            //Dash
            if ((dashBttn || Input.GetKeyDown(KeyCode.LeftShift)) && canDash && currentPlayerIndex == 1)
            {
                StartCoroutine(Dash());
            }
        }
        else
        {
            h = 0;
            //rb.velocity = new Vector2(0f, rb.velocity.y);
            transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);
            Anim[0].SetBool("Run", false);
        }

        AnimationIntParameters("Speed");
        
    }

    void ChangeDirection(int direction)
    {
        Vector3 Scale = transform.localScale;
        Scale.x = direction;
        transform.localScale = Scale;
    }

    public void AnimationIntParameters(string animationParameter)
    {
        for (int i = 0; i < Anim.Length; i++)
        {
            Anim[i].SetInteger(animationParameter, Mathf.Abs((int)h));
        }
    }

    void CheckIfOnGround()
    {
        isOnGround = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.1f, GroundLayer);

        if (isOnGround)
        {
            //canDash = true;
            if (hasJumped)
            {
                hasJumped = false;
                AnimationParameters("Jump", false);

                BtnJmpCat.SetActive(true);
                BtnDblCat.SetActive(false);
            }
            else if (hasdoubleJumped)
            {
                hasdoubleJumped = false;
                AnimationParameters("DoubleJump", false);
            }
        }
    }

    private void PlayerJump()
    {
        if (JumpBttn)
        {
            if (isOnGround)
            {
                hasJumped = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                AnimationParameters("Jump", true);
                doubleJump = true;

                BtnJmpCat.SetActive(false);
                BtnDblCat.SetActive(true);
            }
            else 
            {
                if ((JumpBttn || Input.GetKeyDown(KeyCode.Space)) && currentPlayerIndex == 1 && doubleJump)
                {
                    doubleJumpBttn = false;
                    hasdoubleJumped = true;
                    AnimationParameters("DoubleJump", true);
                    rb.velocity = new Vector2(rb.velocity.x, jump2Power);
                    doubleJump = false;
                }
            }

            JumpBttn = false;
        }


    }

    public void AnimationParameters(string animationParameter, bool animationStatus)
    {
        for (int i = 0; i < Anim.Length; i++)
        {
            Anim[i].SetBool(animationParameter, animationStatus);
        }
    }

    private void ShootAnim()
    {
        if(currentPlayerIndex != 0)
        {
            BalasJugador1.SetActive(false);
            gunImage.SetActive(false);
        }
        else
        {
            BalasJugador1.SetActive(true);
            gunImage.SetActive(true);
        }

        if(currentPlayerIndex == 0 && (Input.GetKeyDown(KeyCode.W) || ShootBttn))
        {
            if (BalasIndex < 7)
            {
                GameObject bullet = Instantiate(RevolverBullet, transform.position, Quaternion.identity);
                bullet.GetComponent<RevolverBullet>().Speed *= transform.localScale.x;
                Anim[0].SetTrigger("Shoot");
                Balas[BalasIndex].SetActive(false);

                AudioManager.instance.PlayOneShot(FMODEvents.instance.shoot, this.transform.position);

                BalasIndex++;
            }
            else if (BalasIndex >= 7)
            {
                BalasIndex = 7;
                AudioManager.instance.PlayOneShot(FMODEvents.instance.emptyGun, this.transform.position);
            }
            ShootBttn = false;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireBall"))
        {
            //Debug.Log("Shoot");
            gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
        if (collision.CompareTag("DropBala"))
        {
            BalasIndex--;

            if (BalasIndex <= 0)
            {
                BalasIndex = 0;
            }

            Balas[BalasIndex].SetActive(true);
            
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;

        Anim[1].SetTrigger("Dash");

        if (h < 0)
        {
            transform.position += new Vector3(dashVelocity * -speed * Time.deltaTime, 0, 0);
        }else
        {
            transform.position += new Vector3(dashVelocity * speed * Time.deltaTime, 0, 0);
        }
        yield return new WaitForSeconds(dashTime);
        yield return new WaitForSeconds(dashWait);
        canDash = true;
        dashBttn = false;
    }
    public void Player1Stats()
    {
        speed = players[currentPlayerIndex].GetComponent<Player>().speed;
        jumpPower = players[currentPlayerIndex].GetComponent<Player>().jumpPower;
        jump2Power = players[currentPlayerIndex].GetComponent<Player>().jump2Power;
        dashVelocity = players[currentPlayerIndex].GetComponent<Player>().dashVelocity;
        dashTime = players[currentPlayerIndex].GetComponent<Player>().dashTime;
        dashWait = players[currentPlayerIndex].GetComponent<Player>().dashWait;
    }

    void DeadAnimation()
    {
        if (PDS.PlayerDead)
        {
            if(currentPlayerIndex == 1)
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.catDeath, this.transform.position);
            }
            Anim[currentPlayerIndex].SetBool("Dead", true);
            this.enabled = false;
        }
    }

    //*******Buttons for phone*******

    public void ShootTriggerButton()
    {
        ShootBttn = true;
    }

    public void JumpButton()
    {
        JumpBttn = true;
    }

    public void RunButton(bool runBttnCheck)
    {
        RunBttn = runBttnCheck;
    }

    public void DashButton()
    {
        dashBttn = true;
    }

}
