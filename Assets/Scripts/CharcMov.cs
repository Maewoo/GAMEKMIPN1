using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CharcMov : MonoBehaviour
{
    
    
    private Rigidbody2D rb2D;
    Animator animator;
    //private bool grounded;
    bool facingRight = true;
    bool isSprinting;
    //private bool isMoving = false;
    //float MovH;

    [SerializeField] float movSpeed;
    [SerializeField] float walkspeed;
    //[SerializeField] float jumpSpeed;
    [SerializeField] float sprintMultiplier;


    //NEW INPUT SYSTEM //
    public PlayerInputAction playerControls;
    private InputAction move;
    private InputAction jump;
    private InputAction sprint;

    private static CharcMov instance;
    Vector2 MovH = Vector2.zero;


    void Awake()
    {
        playerControls = new PlayerInputAction();

        if (instance != null)
        {
            Debug.LogError("Found more than one CharcMov in the scene.");
        }
        instance = this;
        
    }

    public static CharcMov GetInstance() 
    {
        return instance;
    }
    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        /* interact = playerControls.Player.Interact;
        interact.Enable(); */

        /* jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump; */
        playerControls.UI.Enable();

        sprint = playerControls.Player.Sprint;
        sprint.Enable();
        //sprint.performed += sprint;
        playerControls.Player.Sprint.performed += context => isSprinting = true;
        playerControls.Player.Sprint.canceled += context => isSprinting = false;

        
    }
    void OnDisable()
    {
        move.Disable();
        //interact.Disable();
        //jump.Disable();
        sprint.Disable();



    }
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent <Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //MovH = Input.GetAxisRaw("Horizontal");

        if (DialogueManager.GetInstance().dialogueisplaying || ItemExaminer.GetInstance().examineisplaying || InventoryManager.GetInstance().inventoryisactive)
        {
            rb2D.velocity = Vector2.zero;
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsRunning", false);
            //animator.SetBool("IsJumping", false);
            animator.SetFloat("Speed", 0f);
            return;
        }

        else if (!DialogueManager.GetInstance().dialogueisplaying || !ItemExaminer.GetInstance().examineisplaying || !InventoryManager.GetInstance().inventoryisactive){
        movSpeed = isSprinting ? sprintMultiplier : walkspeed;
        animator.SetBool("IsRunning", isSprinting);

        MovH = move.ReadValue<Vector2>();
        MoveHorizontal();
        }

        
        
        
        

        /* if (grounded)
        {
            PlayerJump();
            //animator.SetBool("IsJumping", true);
        } */



        /*if (Input.GetKeyDown(KeyCode.LeftShift)){
            PlayerSprint();  
        }*/


    }

    void MoveHorizontal(){
        rb2D.velocity = new Vector2(MovH.x * movSpeed, rb2D.velocity.y);
        if (MovH.x > 0 && !facingRight || MovH.x < 0 && facingRight)
        {
            Flip();
            
        }
        /*if ()
        {
            Flip();
            
        }*/    
        if (MovH.x == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
        animator.SetFloat("Speed", Mathf.Abs(MovH.x));
        



       /*  if (Input.GetKeyDown(KeyCode.LeftShift)){
            movSpeed = sprintMultiplier;
            animator.SetBool("IsRunning", true);
            Debug.Log("sprinting!");
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            movSpeed = walkspeed;
            animator.SetBool("IsRunning", false);
        } */
    }

    void Flip()
    {
        Vector3 currentscale = gameObject.transform.localScale;
        currentscale.x *= -1;
        gameObject.transform.localScale = currentscale;

        facingRight = !facingRight;
    }
    /* void PlayerJump(){
         rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
         grounded = false;
         animator.SetBool("IsJumping", !grounded);
    } */

    /* void PlayerSprint(){
         movSpeed = sprintMultiplier;
         Debug.Log("sprinting!");
    } */

    /* void Sprint (InputAction.CallbackContext context){
        
        if(context.performed){
        movSpeed = sprintMultiplier;
        animator.SetBool("IsRunning", true);
        Debug.Log("sprinting!");
        }
        else if (context.canceled){
        movSpeed = walkspeed;
        animator.SetBool("IsRunning", false);
        }
    } */

    /* private void Jump(InputAction.CallbackContext context){
        if (grounded){
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        grounded = false;
        animator.SetBool("IsJumping", !grounded);
        }
        
    } */

    public void StopPlayerAnimation(){
         
    }

   /*  public void SetCanMove(bool move)
    {
        canMove = move;
    } */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
           /*  //grounded = true;
            animator.SetBool("IsJumping", false) ; */
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground")){
            //grounded = false;
        }
    }
}
