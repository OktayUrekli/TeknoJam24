using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f; // Karakterin hareket h�z�
    float hareketX, hareketY;

    Animator myAnimator;
   
    Vector2 direction;

    GoblinFightManager goblinFightManager;


    public bool isGoblinInRange;

    GameObject goblinInRange;

    private void Start()
    {
 
  
        goblinFightManager = GetComponent<GoblinFightManager>();
        myAnimator = GetComponent<Animator>();
      
    }
    // Her frame'de �a�r�l�r
    void Update()
    {
        MoveInputs();
        AttackInput();
        Move();
    }
    void MoveInputs()
    {
        hareketX = Input.GetAxis("Horizontal"); // -1 ile 1 aras�nda de�er d�ner (A, D veya sol ok, sa� ok tu�lar� ile)
        hareketY = Input.GetAxis("Vertical"); // -1 ile 1 aras�nda de�er d�ner (W, S veya yukar� ok, a�a�� ok tu�lar� ile) 
        direction=new Vector2(hareketX, hareketY);
        MoveAnims(hareketX, hareketY); 
    }
    
    void AttackInput()
    {
            if (Input.GetKeyDown(KeyCode.Keypad6)) // rigt
            {
                myAnimator.SetTrigger("Left");
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            goblinInRange.GetComponent<GoblinFightManager>().GoblinTakeDamage();
        }
            else if (Input.GetKeyDown(KeyCode.Keypad8)) // up
            {
                myAnimator.SetTrigger("Up");
            goblinInRange.GetComponent<GoblinFightManager>().GoblinTakeDamage();
        }
            else if (Input.GetKeyDown(KeyCode.Keypad5)) // down
            {
                myAnimator.SetTrigger("Down");
            goblinInRange.GetComponent<GoblinFightManager>().GoblinTakeDamage();
        }
            else if (Input.GetKeyDown(KeyCode.Keypad4)) // left
            {
               gameObject.GetComponent<SpriteRenderer>().flipX = true;
               myAnimator.SetTrigger("Left");
            goblinInRange.GetComponent<GoblinFightManager>().GoblinTakeDamage();
        }
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goblin"))
        {
            isGoblinInRange = true;
            goblinInRange = collision.gameObject;
            
        }
        else
        {
            isGoblinInRange = false;
        }
        
    }
    


    void Move()
    {
        // WASD tu�lar� ile hareket
        Vector3 hareket = new Vector3(hareketX, hareketY, 0f); // Hareket vekt�r� olu�turulur
        hareket = Vector3.ClampMagnitude(hareket, 1f); // Hareket vekt�r�n�n b�y�kl��� 1 ile s�n�rlan�r (diagonal hareketlerde a��r� h�z� �nlemek i�in)
        transform.Translate(hareket * speed * Time.deltaTime); // Hareket uygulan�r
    }
    void MoveAnims(float hareketX, float hareketY)
    {
        float animatorSpeed = Mathf.Abs(hareketY) + Mathf.Abs(hareketX);
        myAnimator.SetFloat("Speed", animatorSpeed);

        if (hareketX < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(hareketX > 0) 
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
