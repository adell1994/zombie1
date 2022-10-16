using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSkinedMeshCollider : MonoBehaviour
{

    public float interval;

    private MeshCollider meshCollider;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private float nextTime;

    // Start is called before the first frame update
    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        nextTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        nextTime -= Time.deltaTime;
        if (nextTime < 0.0f)
        {
            nextTime = interval;

            Mesh bakedMesh = new Mesh();
            skinnedMeshRenderer.BakeMesh(bakedMesh,true);
            meshCollider.sharedMesh = null;
            meshCollider.sharedMesh = bakedMesh;
        }
    }
}