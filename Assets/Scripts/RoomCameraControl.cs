using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCameraControl : MonoBehaviour
{
    public Transform[] roomPositions; // Oda konumlarý
    public Transform player;          // Oyuncu objesi
    private Transform currentRoom;
    public Camera camera;
    public float transitionSpeed = 5f;

    void Start()
    {
        currentRoom = roomPositions[0]; // Baþlangýç odasý
        transform.position = currentRoom.position;
    }

    void Update()
    {
        // Kamera yumuþak geçiþ
        camera.transform.position = Vector3.Lerp(camera.transform.position, currentRoom.position-new Vector3(0,0,10), Time.deltaTime * transitionSpeed);
    }

    public void MoveCameraToRoom(Transform newRoom)
    {
        currentRoom = newRoom;
    }
}
