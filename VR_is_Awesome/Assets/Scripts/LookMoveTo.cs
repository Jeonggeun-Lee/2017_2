using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LookMoveTo : MonoBehaviour {
    public GameObject ground;
    public Transform infoBubbe;

    private Text infoText;
	
    void Start()
    {
        if(infoBubbe != null)
        {
            infoText = infoBubbe.Find("Text").GetComponent<Text>();
        }
    }

	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward * 100.0f);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            
                hitObject = hit.collider.gameObject;
                if (hitObject == ground)
                {
                    if(infoBubbe != null)
                    {
                        infoText.text = "X:" + hit.point.x.ToString("F2") + ", Z:" + hit.point.x.ToString("F2");
                        infoBubbe.LookAt(camera.position);
                        infoBubbe.Rotate(0.0f, 180.0f, 0.0f);
                    }
                    Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                    transform.position = hit.point;
                }
            
        }
    }
}
