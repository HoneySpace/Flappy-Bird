using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;

    public float speed = 0.125f;

    public float SpawnTime = 1.5f;
    public GameObject SpawnObject;
    public Vector3 SpawnOffset;
    public float YRange;

   
    // Start is called before the first frame update    

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Target != null) this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, Target.position.x, speed), transform.position.y) +offset;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnTime);
        SpawnOffset.y = Random.Range(-YRange, YRange);
        Instantiate(SpawnObject,new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.scaledPixelWidth, 0, 0)).x, transform.position.y) +SpawnOffset, Quaternion.identity);
        StartCoroutine("Spawn");
        Debug.Log(Input.mousePosition);
    }
}
