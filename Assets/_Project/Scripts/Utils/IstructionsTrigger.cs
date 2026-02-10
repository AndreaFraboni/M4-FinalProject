using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstructionsTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
