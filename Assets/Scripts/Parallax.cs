using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer mr;

    public float animationSpeed = 1f;


    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
