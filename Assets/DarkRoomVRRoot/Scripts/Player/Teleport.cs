using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform m_player;

    private void Start()
    {
        m_player = FindAnyObjectByType<OVRManager>().transform;
    }

    public void TeleportTo()
    {
        m_player.position = transform.position;
        m_player.rotation = transform.rotation;
    }
}
