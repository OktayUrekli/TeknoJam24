using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBombGoblinTower : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] Sprite destroyedTower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Warrior"))
        {
            Invoke("Bomb", 1f);
            Invoke("ChangeImage", 2f);
        }
    }

    void Bomb()
    {
        Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
    }

    void ChangeImage()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = destroyedTower;
    }
}
