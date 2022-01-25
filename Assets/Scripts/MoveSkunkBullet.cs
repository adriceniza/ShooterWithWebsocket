using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSkunkBullet : MonoBehaviour
{
    public Vector3 hitPoint;
    public int speed = 5000;
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col);
        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject ,2f);
        

    }
}
