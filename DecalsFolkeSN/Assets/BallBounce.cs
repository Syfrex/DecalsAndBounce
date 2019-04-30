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
        Vector3 randomStart = new Vector3(Random.Range(-1f, 1), 0, Random.Range(-1f, 1));
        yield return new WaitForSeconds(0.1f);
        Bounce(randomStart * 1000f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WallArea")
        {
            Quaternion Qua = Quaternion.FromToRotation(Vector3.forward, collision.GetContact(0).normal);

            Vector3 hitLocation = new Vector3(
                collision.GetContact(0).point.x + (collision.GetContact(0).normal.x * 0.01f/*offset*/),
                collision.GetContact(0).point.y + (collision.GetContact(0).normal.y * 0.01f/*offset*/),
                collision.GetContact(0).point.z + (collision.GetContact(0).normal.z * 0.01f/*offset*/));

            decalSpawner.DrawDecal(hitLocation, Qua);
        }
    }
    public void Bounce(Vector3 direction)
    {
        rb.AddForce(direction);
    }
}
