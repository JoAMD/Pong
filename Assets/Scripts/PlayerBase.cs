using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private Collider2D baseColliderRef;
    [SerializeField] private PlayerType playerType;

    // Start is called before the first frame update
    void Start()
    {
        BasesManager.instance.AddCollider2D(playerType, baseColliderRef);
    }
}
