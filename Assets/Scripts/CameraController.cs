using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField] Tilemap tilemap;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHight;
    private float halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.instance.transform;
        //target = FindObjectOfType<PlayerController>().transform;

        halfHight = Camera.main.orthographicSize;
        halfWidth = halfHight * Camera.main.aspect;

        bottomLeftLimit = tilemap.localBounds.min + new Vector3(halfWidth, halfHight,0f);
        topRightLimit = tilemap.localBounds.max + new Vector3(-halfWidth, -halfHight,0f);

        PlayerController.instance.SetBounds(tilemap.localBounds.min, tilemap.localBounds.max);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        // keep camera inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,bottomLeftLimit.x,topRightLimit.x),Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),transform.position.z);
    }
}
