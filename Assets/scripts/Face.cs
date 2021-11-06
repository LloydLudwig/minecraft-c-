using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Face : MonoBehaviour {

    public Material BaseShader;

    public GameObject ParentObject;
    
    public Texture BlockTextureNorth;
    public Texture BlockTextureSouth;
    public Texture BlockTextureWest;
    public Texture BlockTextureEast;
    public Texture BlockTextureUp;
    public Texture BlockTextureDown;



    Vector3[] vertices = new Vector3[4];

    Vector2[] UVs = {
        new Vector2(0, 1),
        new Vector2(1, 1),
        new Vector2(0, 0),
        new Vector2(1, 0),
    };

    int[] triangles = {
        0, 1, 2, //A
        2, 1, 3, //B
    };

    public Face(Texture texture, string direction, GameObject ParentObject) {
       
        setFacesVertices(direction);
        
        //set mesh structure and values
        Mesh face = new Mesh();
        face.Clear();
        face.vertices = vertices;
        face.uv = UVs;
        face.triangles = triangles;

        GameObject face_obs = new GameObject("face", typeof(MeshFilter), typeof(MeshRenderer));
        face_obs.GetComponent<MeshFilter>().mesh = face;
        face_obs.GetComponent<MeshRenderer>().material.mainTexture = texture;
        face_obs.GetComponent<Renderer>().sharedMaterial.SetFloat("Smoothness", .0f);
        face_obs.AddComponent<MeshCollider>();
        face_obs.transform.position = new Vector3(0, 2, 0);

        face_obs.transform.parent = ParentObject.transform;
        

    }

    private void setFacesVertices(string direction) {
        switch (direction) {
            case ("north"):
                vertices[0] = new Vector3((float)(-0.5), (float)(0.5), (float)(-0.5)); //A
                vertices[1] = new Vector3((float)(0.5), (float)(0.5), (float)(-0.5)); //B
                vertices[2] = new Vector3((float)(-0.5), (float)(-0.5), (float)(-0.5)); //C
                vertices[3] = new Vector3((float)(0.5), (float)(-0.5), (float)(-0.5)); //D
                break;
            case ("south"):
                vertices[0] = new Vector3((float)(0.5), (float)(0.5), (float)(0.5)); //E
                vertices[1] = new Vector3((float)(-0.5), (float)(0.5), (float)(0.5)); //F
                vertices[2] = new Vector3((float)(0.5), (float)(-0.5), (float)(0.5)); //G
                vertices[3] = new Vector3((float)(-0.5), (float)(-0.5), (float)(0.5)); //H
                break;
            case ("west"):
                vertices[0] = new Vector3((float)(0.5), (float)(0.5), (float)(-0.5)); //B
                vertices[1] = new Vector3((float)(0.5), (float)(0.5), (float)(0.5)); //E
                vertices[2] = new Vector3((float)(0.5), (float)(-0.5), (float)(-0.5)); //D
                vertices[3] = new Vector3((float)(0.5), (float)(-0.5), (float)(0.5)); //G
                break;
            case ("east"):
                vertices[0] = new Vector3((float)(-0.5), (float)(0.5), (float)(0.5)); //F
                vertices[1] = new Vector3((float)(-0.5), (float)(0.5), (float)(-0.5)); //A
                vertices[2] = new Vector3((float)(-0.5), (float)(-0.5), (float)(0.5)); //H
                vertices[3] = new Vector3((float)(-0.5), (float)(-0.5), (float)(-0.5)); //C
                break;
            case ("up"):
                vertices[0] = new Vector3((float)(-0.5), (float)(0.5), (float)(0.5)); //F
                vertices[1] = new Vector3((float)(0.5), (float)(0.5), (float)(0.5)); //E
                vertices[2] = new Vector3((float)(-0.5), (float)(0.5), (float)(-0.5)); //A
                vertices[3] = new Vector3((float)(0.5), (float)(0.5), (float)(-0.5)); //B
                break;
            case ("down"):
                vertices[0] = new Vector3((float)(-0.5), (float)(-0.5), (float)(-0.5)); //C
                vertices[1] = new Vector3((float)(0.5), (float)(-0.5), (float)(-0.5)); //D
                vertices[2] = new Vector3((float)(-0.5), (float)(-0.5), (float)(0.5)); //H
                vertices[3] = new Vector3((float)(0.5), (float)(-0.5), (float)(0.5)); //G
                break;
            default:
                break;
        }

    }

    void Start() {
        Face Face01 = new Face(BlockTextureNorth, "north", ParentObject);
        Face Face02 = new Face(BlockTextureSouth, "south", ParentObject);
        Face Face03 = new Face(BlockTextureWest, "west", ParentObject);
        Face Face04 = new Face(BlockTextureEast, "east", ParentObject);
        Face Face05 = new Face(BlockTextureUp, "up", ParentObject);
        Face Face06 = new Face(BlockTextureDown, "down", ParentObject);

    }
    
    void Update() {

    }

}