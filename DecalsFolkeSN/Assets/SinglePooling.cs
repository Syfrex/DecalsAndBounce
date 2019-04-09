using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePooling : MonoBehaviour
{
    public Material[] SphereMaterials;
    public GameObject Ball;
    GameObject[] Spheres;
    public Transform spawnPos;
    Vector3 RandomForce;
    void Start()
    {
        Spheres = new GameObject[SphereMaterials.Length];
        for (int i = 0; i < SphereMaterials.Length; i++)
        {

            Spheres[i] = GameObject.Instantiate(Ball);  
            Spheres[i].GetComponent<MeshRenderer>().material = SphereMaterials[i];
            Spheres[i].SetActive(false);
        }
    }
    public void ClickyClicky()
    {
        RandomForce = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * 1000f;

        for (int i = 0; i < Spheres.Length; i++)
        {
            if(Spheres[i].activeInHierarchy == false)
            {
                Spheres[i].SetActive(true);
                Spheres[i].transform.position = spawnPos.position;
                //Spheres[i].GetComponent<BallBounce>().Bounce(RandomForce);
                StartCoroutine(waitforforce(Spheres[i], RandomForce));
                break;
            }
        }
    }
    IEnumerator waitforforce(GameObject forcethis, Vector3 Force)
    {
        //Debug.Log("Error: " + RandomForce);

        yield return new WaitForSeconds(0.1f);
        forcethis.GetComponent<BallBounce>().Bounce(Force);
    }
}
