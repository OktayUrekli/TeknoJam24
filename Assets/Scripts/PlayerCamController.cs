using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    [SerializeField] Transform player; // Kameran�n takip edece�i karakterin transformu
    [SerializeField] Vector3 offset; // Kameran�n karakterden ne kadar uzakta olaca��

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (player != null)
        {
            // Kameran�n hedef konumu
            Vector3 hedefKonum = player.position + offset;
            // Kameran�n yumu�ak bir �ekilde hedefe do�ru ilerlemesi
            transform.position = Vector3.Lerp(transform.position, hedefKonum, Time.deltaTime * 5f);
        }
    }
}
