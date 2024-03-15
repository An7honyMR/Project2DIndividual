using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;

        // Verifica si el GameObject colisionado es el que quieres destruir
        if (otherObject.CompareTag("ItemBad") || otherObject.CompareTag("ItemGood") || otherObject.CompareTag("Ground"))
        {
            Destroy(otherObject);
        }
    }
}
