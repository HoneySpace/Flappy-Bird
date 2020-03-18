using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSettings : MonoBehaviour
{
    public GameObject Tube;
    public float Space;
    const float nullSpace= 1.75f;

    public float DestroyDist=7f;
    void Start()
    {
        Vector2[] edgPoint = new Vector2[2];
        Space += nullSpace;
        GameObject half = Instantiate(Tube, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)), transform);
        half.transform.localPosition = new Vector3(0, -Space,0);
        edgPoint[0] = new Vector3(0,-Space/2);
        half = Instantiate(Tube, transform.position, Quaternion.Euler(new Vector3(0, 0, -180)), transform);
        half.transform.localPosition = new Vector3(0, Space, 0);
        edgPoint[1] = new Vector3(0, Space/2);
        EdgeCollider2D edge = this.gameObject.AddComponent<EdgeCollider2D>();
        edge.points = edgPoint;
        edge.isTrigger = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Camera.main.transform.position.x - this.transform.position.x > DestroyDist) Destroy(this.gameObject);  
    }
}
