using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCameraControl : MonoBehaviour
{
    public Transform[] roomPositions; // Oda konumlarý
    public Transform player;          // Oyuncu objesi
    private Transform currentRoom;
    public Camera camerax;
    public float transitionSpeed = 5f;
    public CameraSpawner cameraspawn;
    void Start()
    {
      
        currentRoom = roomPositions[0]; // Baþlangýç odasý
        transform.position = currentRoom.position;
    }

    void Update()
    {
        // Kamera yumuþak geçiþ
        camerax.transform.position = Vector3.Lerp(camerax.transform.position, currentRoom.position-new Vector3(0,0,10), Time.deltaTime * transitionSpeed);
    }

    public void MoveCameraToRoom(Transform newRoom)
    {
        Debug.Log("cHANGER");
       
        cameraspawn.ActivateRoom();
        currentRoom = newRoom;
    }
}
