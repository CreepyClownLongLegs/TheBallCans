using Systems.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour, IDataPersistence
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] float speed = 7f;
    Vector2 motionVector;
    public bool elevatorPanelIsOpen = false;
    string current_anim = "idlemc";

    public float speedX_addOn = 0f;
    public float speedY_addOn = 0f;

    private void OnEnable(){
        InputSystem.onJump += Jump;
        InputSystem.goingDown += goingDownAnimation;
        InputSystem.goingUp += goingUpAnimation;
        InputSystem.goingLeft += goingLeftAnimation;
        InputSystem.goingRight += goingRightAnimation;
        InputSystem.onIdle += idleAnimation;
    }   

    private void OnDisable(){
        InputSystem.onJump -= Jump;
        InputSystem.goingDown -= goingDownAnimation;
        InputSystem.goingUp -= goingUpAnimation;
        InputSystem.goingLeft -= goingLeftAnimation;
        InputSystem.goingRight -= goingRightAnimation;
        InputSystem.onIdle -= idleAnimation;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"),
        Input.GetAxisRaw("Vertical"));
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(DialogueManager.Instance.dialogueIsPlaying || elevatorPanelIsOpen || SceneLoader.Instance.isLoading) {
            rb.velocity = new Vector2(0,0);
            motionVector = new Vector2(0,0);
            idleAnimation();
            changePlayerAnimation();
            return;
            }
        move();
        changePlayerAnimation();
    }

    void move(){
        rb.velocity = new Vector2( motionVector.x*speed + speedX_addOn, motionVector.y*speed + speedY_addOn);
    }
    
    private void Jump(){
        Debug.Log("Jump");
    }

    void changePlayerAnimation(){

        animator.Play(current_anim);
    }

    void goingDownAnimation(){
        current_anim = "walkingupmc";
        if(SceneLoader.Instance.loadedScenes.Contains("CookingMinigameUI")){
            current_anim = "cookingDown";
        }
        kayakingAnimation();
    }

    void goingRightAnimation(){
        current_anim = "walkingrightmc";
        if(SceneLoader.Instance.loadedScenes.Contains("CookingMinigameUI")){
            current_anim = "cookingRight";
        }
        kayakingAnimation();
    }

    void goingLeftAnimation(){
        current_anim = "walkingleftmc";
        if(SceneLoader.Instance.loadedScenes.Contains("CookingMinigameUI")){
            current_anim = "cookingLeft";
        }
        kayakingAnimation();
    }

    void idleAnimation(){
        current_anim = "idlemc";
        if(SceneLoader.Instance.loadedScenes.Contains("CookingMinigameUI")){
            current_anim = "cookingIdle";
        }
        kayakingAnimation();
    }

    void goingUpAnimation(){
        current_anim = "walkingmc";
        if(SceneLoader.Instance.loadedScenes.Contains("CookingMinigameUI")){
            current_anim = "cookingUp";
        }
        kayakingAnimation();
    }

    void kayakingAnimation(){
        if(SceneLoader.Instance.loadedScenes.Contains("KayakingMiniGameUI")){
            current_anim = "kayaking";
        }
    }

    public void LoadGame(GameData data)
    {
    }

    public void SaveGame(GameData data)
    {
    }
}
