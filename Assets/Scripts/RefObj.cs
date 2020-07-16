using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefObj : MonoBehaviour
{
    public GameObject obj;
    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        SetPosAndRot();
    }

    // Update is called once per frame
    void Update()
    {
        SetPosAndRot();
    }

    void SetPosAndRot()
    {
        if(obj == null || plane == null)
        {
            return;
        }

        /*
         * compute position
         * https://docs.unity3d.com/ScriptReference/Vector3.Reflect.html
         */

        MeshFilter mf = plane.GetComponent<MeshFilter>();
        Vector3[] nor = mf.mesh.normals;
        Vector3 plane_normal = nor[0];

        Vector3 p_pos = obj.transform.position - plane.transform.position;
        Vector3 reflectedObject_position = Vector3.Reflect(p_pos, plane_normal);
        transform.position = reflectedObject_position + plane.transform.position;

        /*
         * compute rotation
         */
        Vector3 forward = Vector3.Reflect(obj.transform.forward, plane_normal);
        Vector3 up = Vector3.Reflect(obj.transform.up, plane_normal);

        Quaternion rotation = Quaternion.LookRotation(forward, up);
        transform.rotation = rotation;

    }
}
