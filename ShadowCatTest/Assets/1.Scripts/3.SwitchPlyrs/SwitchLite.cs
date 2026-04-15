using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLite : MonoBehaviour
{
    //Players Array
    public GameObject[] players;
    private int currentPlayerIndex = 0;
    [SerializeField] private GameObject revolverBullet;
    [SerializeField] private GameObject escopetaBullet;
    private bool isShotgunShoot = false;
    private float shotgunTimer = 0;

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

    //BalasUIImages
    [SerializeField] private BalasUIManager balasUIManager;

    //Script
    public PlayerDamage playerDamageScript;

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

    //ButtonsSwhitch
    public GameObject BttnsDetective, BttnsCat;
    public GameObject BtnJmpCat, BtnDblCat;

    //Music
    //public MusicBehaviour MusicBehaviourInstance { get; set; }
    //public IMusicObserver MusicObserverInstance { get; set; }
    public MusicBridge levelMusic;

    [SerializeField] private Image fillImage;
    float waitTime = 30.0f;
    float timerCatBttn = 0f;
    bool slowBttn = false;

    //Slow Button Barrier

    public GameObject slowbutonbarrier;
    float slowMultiplayer = 2f;

    //Cosas BosFight

    [HideInInspector] public bool isInCinematic = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //GameObject music = GameObject.Find("Music");
        //MusicBehaviourInstance = music.GetComponent<MusicBehaviour>();
        //MusicObserverInstance = MusicBehaviourInstance;

        GameObject instanciaMusic = GameObject.Find("Music");
        levelMusic = instanciaMusic.GetComponent<MusicBridge>();
        levelMusic.NotificarCambioMusica("JuegoEnCurso");

        playerDamageScript.PuedeRecibirDaño(true);

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

        //BalasIndex = StateGameController.bulletsInGame - 1;
    }

    void Update()
    {
        ShootAnim();
        CheckIfOnGround();

        Player1Stats();
        DeadAnimation();

        ShootgunCooldown();
    }

    void FixedUpdate()
    {
        if (!isInCinematic)
        {
            PlayerWalk();
            PlayerJump();
            SwitchButtons();
            SlowMechanic();
        }
        else
        {
            for (int i = 0; i < Anim.Length; i++)
            {
                Anim[i].SetInteger("Speed", 0);
            }
        }
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
            levelMusic.NotificarCambioMusica("EsGato", false);
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.detectiveSong, this.transform.position);
        }
        else
        {
            //AudioManager.instance.PlayOneShot(FMODEvents.instance.catSong, this.transform.position);
            levelMusic.NotificarCambioMusica("EsGato", true);
        }

        players[currentPlayerIndex].SetActive(true);
        Anim[currentPlayerIndex].SetTrigger("Puff");
        AudioManager.instance.PlayOneShot(FMODEvents.instance.transformFX, this.transform.position);

        //musicBehaviour.estadoTransform = transformMusicValue;
        //}
    }

    private void SwitchButtons()
    {
        if (currentPlayerIndex == 0)
        {
            BttnsDetective.SetActive(true);
            BttnsCat.SetActive(false);
            StateGameController.isCat = false;    
            
        }
        if (currentPlayerIndex == 1)
        {
            BttnsDetective.SetActive(false);
            BttnsCat.SetActive(true);
            StateGameController.isCat = true;
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
            transform.position += new Vector3(h * speed * Time.fixedDeltaTime * StateGameController.playerTime, 0, 0);

            ChangeDirection(1);
            Anim[0].SetBool("Run", false);
            if (currentPlayerIndex == 0 && (Input.GetKey(KeyCode.LeftShift) || RunBttn))
            {
                Anim[0].SetBool("Run", true);
                //rb.velocity = new Vector2(speed *1.5f, rb.velocity.y);
                transform.position += new Vector3(h * speed * Time.fixedDeltaTime * StateGameController.playerTime, 0, 0);
            }
            //Dash
            /*if ((dashBttn || Input.GetKeyDown(KeyCode.LeftShift)) && canDash && currentPlayerIndex == 1)
            {
                StartCoroutine(Dash());
            }*/
        }   //if (h < 0)
        else if (joystick.Horizontal < 0)
        {
            h = -1f;
            //AnimationIntParameters("Speed");
            //rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.position += new Vector3(h * speed * Time.fixedDeltaTime * StateGameController.playerTime, 0, 0);

            ChangeDirection(-1);
            Anim[0].SetBool("Run", false);
            if (currentPlayerIndex == 0 && (Input.GetKey(KeyCode.LeftShift) || RunBttn))
            {
                Anim[0].SetBool("Run", true);
                //rb.velocity = new Vector2(-speed * 1.5f, rb.velocity.y);
                transform.position += new Vector3(h * speed * Time.fixedDeltaTime * StateGameController.playerTime, 0, 0);
            }
            //Dash
            /*if ((dashBttn || Input.GetKeyDown(KeyCode.LeftShift)) && canDash && currentPlayerIndex == 1)
            {
                StartCoroutine(Dash());
            }*/
        }
        else
        {
            h = 0;
            //rb.velocity = new Vector2(0f, rb.velocity.y);
            transform.position += new Vector3(h * speed * Time.fixedDeltaTime * StateGameController.playerTime, 0, 0);
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
            //Debug.Log("JumpBttn");
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
        if (currentPlayerIndex != 0)
        {
            balasUIManager.ActivarDesactivarTodasLasBalas(false);
        }
        else
        {
            balasUIManager.ActivarDesactivarTodasLasBalas(true);
        }

        if (currentPlayerIndex == 0 && (Input.GetKeyDown(KeyCode.W) || ShootBttn))
        {
            if (StateGameController.NumeroDeArmaEquipada == 0) // Si arma es revolver
            {
                if (balasUIManager.RevolverBalasIndex > -1)
                {
                    GameObject bullet = Instantiate(revolverBullet, transform.position + new Vector3(0.25f,0.17f,0), Quaternion.identity);
                    bullet.GetComponent<RevolverBullet>().Speed *= transform.localScale.x;

                    Anim[0].SetTrigger("Shoot");

                    AudioManager.instance.PlayOneShot(FMODEvents.instance.shoot, this.transform.position);

                    balasUIManager.RemoverBalasRevolver();
                }
                else if (balasUIManager.RevolverBalasIndex <= -1)
                {
                    balasUIManager.RevolverBalasIndex = -1;
                    AudioManager.instance.PlayOneShot(FMODEvents.instance.emptyGun, this.transform.position);
                }
            } 
            else if (StateGameController.NumeroDeArmaEquipada == 1) // Si arma es escopeta
            {  
                if (!isShotgunShoot)
                {
                    if (balasUIManager.EscopetaBalasIndex > -1)
                    {
                        float[] angles = new float[StateGameController.NumeroBalasEscopeta];

                        for (int i = 0; i < angles.Length; i++)
                        {
                            angles[i] = Random.Range(-3f,4f);
                        }

                        foreach (float angle in angles)
                        {
                            GameObject bullet = Instantiate(escopetaBullet, transform.position + new Vector3(0.25f, 0.21f, 0), Quaternion.identity);

                            float directionX = transform.localScale.x;
                            Vector2 baseDirection = new Vector2(directionX, 0f);

                            Vector2 rotatedDirection = Quaternion.Euler(0, 0, angle) * baseDirection;

                            bullet.GetComponent<EscopetaBulletPrefab>().SetDirection(rotatedDirection);
                        }

                        AudioManager.instance.PlayOneShot(FMODEvents.instance.shoot, this.transform.position);
                        Anim[0].SetTrigger("Shotgun");
                        balasUIManager.RemoverBalasEscopeta();
                    }
                    else if (balasUIManager.EscopetaBalasIndex <= -1)
                    {
                        balasUIManager.EscopetaBalasIndex = -1;
                        AudioManager.instance.PlayOneShot(FMODEvents.instance.emptyGun, this.transform.position);
                    }
                }

                isShotgunShoot = true;
            }
            ShootBttn = false;
        }
    }

    private void ShootgunCooldown()
    {
        if (isShotgunShoot)
        {
            shotgunTimer += Time.deltaTime;
            if (shotgunTimer > 0.5f)
            {
                isShotgunShoot = false;
                shotgunTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireBall"))
        {
            gameObject.GetComponent<PlayerDamage>().DealDamage();
        }

        if (collision.CompareTag("RatAttack"))
        {
            playerDamageScript.RatDamage();
        }

        if (collision.CompareTag("DropBala"))
        {
            balasUIManager.AgregarBalasRevolver();
            balasUIManager.AgregarBalasEscopeta();
        }
    }

    private void SlowMechanic()
    {
        if (slowBttn)
        {
            slowbutonbarrier.SetActive(false);
            StateGameController.enemiesTime = 0.2f;
            StateGameController.playerTime = 0.8f;
            Anim[0].speed = 0.8f;
            Anim[1].speed = 0.8f;
            StartCoroutine(SlowMechanicCo(StateGameController.slowdownTime));
            slowBttn = false;
        }
    }

    IEnumerator SlowMechanicCo(float time)
    {
        levelMusic.NotificarCambioMusica("RalentizarEnUso", true);
        yield return new WaitForSeconds(time);        
        slowbutonbarrier.SetActive(true);
        StateGameController.enemiesTime = 1f;
        StateGameController.playerTime = 1f;
        Anim[0].speed = 1f;
        Anim[1].speed = 1f;
        levelMusic.NotificarCambioMusica("RalentizarEnUso", false);
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
        if (playerDamageScript.IsPlayerDead)
        {
            if (currentPlayerIndex == 1)
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.catDeath, this.transform.position);
            }
            Anim[currentPlayerIndex].SetBool("Dead", true);
            levelMusic.NotificarCambioMusica("Perder");
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

    public void SlowButton()
    {
        slowBttn = true;
    }
}
