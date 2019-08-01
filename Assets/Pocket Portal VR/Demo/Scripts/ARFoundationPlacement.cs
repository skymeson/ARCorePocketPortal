using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if USES_AR_FOUNDATION
using UnityEngine.XR.ARFoundation;
#endif

public class ARFoundationPlacement : MonoBehaviour
{

#if USES_AR_FOUNDATION
    public ARSessionOrigin sessionOrigin;
#endif

#if USES_AR_FOUNDATION
    ARRaycastManager raycastManager;
#endif

    // Use this for initialization
    void Start()
    {
#if USES_AR_FOUNDATION
        raycastManager = FindObjectOfType<ARRaycastManager>();
#endif
    }

    // Update is called once per frame
    void Update() {
#if USES_AR_FOUNDATION
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            print("SCREEN TOUCHED!");
            List<ARRaycastHit> results = new List<ARRaycastHit>();
            //sessionOrigin.Raycast(Input.GetTouch(0).position, results, UnityEngine.Experimental.XR.TrackableType.Planes);
            //sessionOrigin.

            var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            var hits = new List<ARRaycastHit>();
            //raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
            raycastManager.Raycast(screenCenter, hits);


            if (results.Count > 0) {
                print("Plane HIT!!");
                ARRaycastHit hit = results[0];
                this.gameObject.transform.position = hit.pose.position;
            }
        }
#endif
    }
}
