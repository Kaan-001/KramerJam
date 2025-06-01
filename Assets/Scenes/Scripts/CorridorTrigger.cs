using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorTrigger : MonoBehaviour
{
    public enum CorridorDirection
    {
        Horizontal, // Sağ <-> Sol
        Vertical    // Yukarı <-> Aşağı
    }

    public CorridorDirection directionMode = CorridorDirection.Horizontal;

    public Transform leftOrDownRoom;
    public Transform rightOrUpRoom;
    public RoomCameraControl cameraControl;
    public Transform player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform != player)
            return;

        Vector3 directionToPlayer = player.position - transform.position;
        Vector3 normalizedDirection = directionToPlayer.normalized;
        Debug.Log("Flag");
        switch (directionMode)
        {
            case CorridorDirection.Horizontal:
                float dotH = Vector3.Dot(transform.right, normalizedDirection);
                if (dotH > 0)
                    cameraControl.MoveCameraToRoom(rightOrUpRoom);
                else
                    cameraControl.MoveCameraToRoom(leftOrDownRoom);
                break;

            case CorridorDirection.Vertical:
                float dotV = Vector3.Dot(transform.up, normalizedDirection);
                if (dotV > 0)
                    cameraControl.MoveCameraToRoom(rightOrUpRoom);
                else
                    cameraControl.MoveCameraToRoom(leftOrDownRoom);
                break;
        }
    }
}