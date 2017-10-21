using UnityEngine;
using System.Collections;

public class ToolUser : MonoBehaviour {
    public GameObject[] pieces;
	public Material capMaterial;
   
	// Use this for initialization
	void Start () {

		
	}
	
	void Update(){

		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {

                GameObject victim = hit.collider.gameObject;

                GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                //if (pieces[0].GetComponent<MeshCollider>())
                //{

                //    Destroy(pieces[0].GetComponent<MeshCollider>());
                //    pieces[0].AddComponent<MeshCollider>();
                //    pieces[0].GetComponent<MeshCollider>().convex = true;
                //    pieces[0].AddComponent<Rigidbody>();

                //}
             
                
                print(pieces[0].GetComponent<MeshCollider>().convex);
                if (!pieces[1].GetComponent<Rigidbody>())
                {
                    pieces[1].AddComponent<Rigidbody>();
                    pieces[1].GetComponent<Rigidbody>().isKinematic = false;
                }
 
                if (!pieces[1].GetComponent<MeshCollider>())
                {
                    pieces[1].AddComponent<MeshCollider>();
                    pieces[1].GetComponent<MeshCollider>().convex = true;
                    pieces[1].GetComponent<MeshCollider>().inflateMesh = true;
                }
                if (pieces[1].transform.position.y <= -1)
                {
                    Destroy(pieces[1], 1);
                    print("asdf");
                }

            }
        }
        
    }

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position,  transform.position + -transform.up * 0.5f);

	}

}
