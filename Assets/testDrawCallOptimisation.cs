using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDrawCallOptimisation : MonoBehaviour
{
    public Material mainMaterial;
    // Start is called before the first frame update
    void Start()
    {
        optimise();
    }


    void optimise()
    {


        GameObject[] parents = GameObject.FindGameObjectsWithTag("GroupOfTerrainStaticMeshes");

        foreach (GameObject parent in parents)
        {

            Vector3 pose = parent.transform.position;
            Quaternion rot = parent.transform.rotation;
            parent.transform.rotation = Quaternion.identity;
            parent.transform.position = Vector3.zero;

            MeshFilter[] meshFilters = parent.transform.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].GetComponent<MeshRenderer>().enabled = false;//gameObject.SetActive(false);

                i++;
            }

            Mesh mesh = new Mesh();

            Debug.Log(combine.Length);
            mesh.CombineMeshes(combine, true);
            if (!parent.transform.GetComponent<MeshFilter>()) parent.AddComponent(typeof(MeshFilter));
            if (!parent.transform.GetComponent<MeshRenderer>()) parent.AddComponent(typeof(MeshRenderer));

            parent.transform.GetComponent<MeshFilter>().sharedMesh = mesh;
            parent.transform.GetComponent<MeshRenderer>().sharedMaterial = mainMaterial;
            parent.transform.GetComponent<MeshRenderer>().enabled = true;//.gameObject.SetActive(true);
            parent.transform.rotation = rot;
            parent.transform.position = pose;
            /* MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
             CombineInstance[] combine = new CombineInstance[meshFilters.Length];

             int i = 0;
             while (i < meshFilters.Length)
             {
                 Debug.LogError(meshFilters[i].name);
                 combine[i].mesh = meshFilters[i].sharedMesh;

                 combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                 meshFilters[i].gameObject.SetActive(false);

                 i++;
             }


             Mesh mesh = new Mesh();
             mesh.CombineMeshes(combine,true,true,false);

             transform.GetComponent<MeshFilter>().sharedMesh = mesh;
             transform.gameObject.SetActive(true);
            */

        }
        /*

        }*/

    }
}

