using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityFollowing : MonoBehaviour
{
    public float Percent;
    Transform camTransf;
    float TextureWidth;
    private void Awake()
    {
        camTransf = Camera.main.transform;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        TextureWidth = texture.width / sprite.pixelsPerUnit;
    }
    void LateUpdate()
    {
        if(camTransf.position.x -transform.position.x >= TextureWidth*Percent)
        {
            float xoffset = (camTransf.position.x - transform.position.x) % TextureWidth;
            transform.position = new Vector3(camTransf.position.x + xoffset, transform.position.y);
        }
    }
}
