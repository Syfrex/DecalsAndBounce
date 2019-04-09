using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Decal decalSpawner;
    Rigidbody rb;
    void Start()
    {
        decalSpawner = GetComponent<Decal>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(waitforforce());

    }
    IEnumerator waitforforce()
    {
        //Debug.Log("Error: " + RandomForce);
        Vector3 randomStart = new Vector3(Random.Range(-1f, 1), 0, Random.Range(-1f, 1));
        yield return new WaitForSeconds(0.1f);
        Bounce(randomStart * 1000f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WallArea")
        {
            Quaternion Qua = Quaternion.FromToRotation(Vector3.forward, collision.gameObject.GetComponent<MeshFilter>().mesh.normals[0]); 
            Vector3 hitLocation = new Vector3(transform.position.x - GetComponent<MeshFilter>().mesh.bounds.extents.x, transform.transform.position.y - GetComponent<MeshFilter>().mesh.bounds.extents.x, transform.position.z - GetComponent<MeshFilter>().mesh.bounds.extents.x);
            decalSpawner.AddDecals(Matrix4x4.TRS(hitLocation, Qua, Vector3.one));
        }
    }
    public void Bounce(Vector3 direction)
    {
        rb.AddForce(direction);
    }
}
