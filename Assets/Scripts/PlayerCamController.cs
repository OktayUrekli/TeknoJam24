using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    [SerializeField] Transform player; // Kameranýn takip edeceði karakterin transformu
    [SerializeField] Vector3 offset; // Kameranýn karakterden ne kadar uzakta olacaðý

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (player != null)
        {
            // Kameranýn hedef konumu
            Vector3 hedefKonum = player.position + offset;
            // Kameranýn yumuþak bir þekilde hedefe doðru ilerlemesi
            transform.position = Vector3.Lerp(transform.position, hedefKonum, Time.deltaTime * 5f);
        }
    }
}
