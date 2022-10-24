using UnityEngine;

public class FirstPlayer : MonoBehaviour
{
  public static int health = 100;
  public static int maxHealth = 100;
  public static int damage = 50;

  public static bool willAttack = false;

  public float walkSpeed = 4f;
  public float jumpSpeed = 5f;
  public float turnSpeed = 50f;

  private CharacterController cc;
  private float horizontalMove;
  private float verticalMove;

  public float gravity = 14f;
  private Vector3 velocity;

  // check whether touch the ground
  public Transform groundCheck;
  public float checkRadius = 0.4f;
  public LayerMask groundLayer;
  public bool isGround;

  // Start is called before the first frame update
  void Start()
  {
    health = 100;
    cc = GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0)) {
      willAttack = true;
    }
    isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

    // when in ground, make velocity of y axis become a costant
    if (isGround && velocity.y < 0) {
      velocity.y = -2f;
    }

    //horizontalMove = Input.GetAxis("Horizontal") * turnSpeed;
    //transform.Rotate(0, horizontalMove * Time.deltaTime, 0);
    horizontalMove = Input.GetAxis("Horizontal") * walkSpeed;
    verticalMove = Input.GetAxis("Vertical") * walkSpeed;
    Vector3 dir = transform.forward * verticalMove + transform.right * horizontalMove;
    cc.Move(dir * Time.deltaTime);

    if (Input.GetButtonDown("Jump") && isGround) {
      velocity.y = jumpSpeed;
    }
    
    velocity.y -= gravity * Time.deltaTime;
    cc.Move(velocity * Time.deltaTime);
  }

  public static void RemoveHealth (int damage)
  {
    GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
    RectTransform CanvasRC = Canvas.GetComponent<RectTransform>();
    GameObject MyHP = GameObject.FindGameObjectWithTag("MyHP");
    RectTransform MyHPRC = MyHP.GetComponent<RectTransform>();
    int actualDamage = health;
    if (health - damage > 0)
    {
      actualDamage = damage;
    }
    float ratio = (float) actualDamage / maxHealth;
    CanvasUtils.ReducePlayerRight(MyHPRC, (float) ratio);
    // MyHPRC.offsetMax = new Vector2(MyHPRC.offsetMax.x - right, MyHPRC.offsetMax.y);
    health = health - actualDamage;
    if (health <= 0)
    {
      Die();
    }
  }


  public static void Die ()
  {
    GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
    GameObject YouDie = GameObject.FindGameObjectWithTag("YouDie");
    Canvas.GetComponent<CanvasGroup>().alpha = 0f;
    YouDie.GetComponent<CanvasGroup>().alpha = 1f;
  }
  
  public static bool DetectSlash ()
  {
    if (health <= 0) return false;
    BoxCollider monsterCollider = GameObject.FindGameObjectWithTag("Monster").GetComponent<BoxCollider>();
    SkinnedMeshRenderer playerSwordCollider = GameObject.FindGameObjectWithTag("PlayerSword").GetComponent<SkinnedMeshRenderer>();
    bool causeDamage = playerSwordCollider.bounds.Intersects(monsterCollider.bounds);
    return causeDamage;
    if (causeDamage)
    {
      Monster.RemoveHealth(damage);
    }
  }
}