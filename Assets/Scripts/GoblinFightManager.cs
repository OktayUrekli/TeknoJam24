using UnityEngine;
using UnityEngine.UI;

public class GoblinFightManager : MonoBehaviour
{
    Animator animator;
    [SerializeField] float healt;
    [SerializeField] Image healtBar;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        healt = 100;
    }
        

    public void GoblinTakeDamage()
    {
        healt -= 50;
        Debug.Log(healt);
        healtBar.fillAmount = healt/100f;
        if (healt<=0)
        {
            animator.SetBool("isDead", true);
            Invoke("DestroyGoblin", 2f);
        }
    }

    void DestroyGoblin()
    {
        Destroy(gameObject);
    }
}
