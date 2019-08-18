using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Face : MonoBehaviour {

    public Texture BlockTexture;
    /*
    Vector3[] vertices = {
            
            new Vector3(0, 1, 0), //a : 0
            new Vector3(1, 1, 0), //b : 1
            new Vector3(0, 0, 0), //c : 2
            new Vector3(1, 0, 0), //d : 3
            ///////////////////////////////
            new Vector3(1, 1, 1), //e : 4
            new Vector3(0, 1, 1), //f : 5
            new Vector3(1, 0, 1), //g : 6
            new Vector3(0, 0, 1), //h : 7    
    };*/

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

    public Face(Texture texture, string direction) {
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
        face_obs.AddComponent<MeshCollider>();

    }

    private void setFacesVertices(string direction) {
        switch (direction) {
            case ("north"):
                vertices[0] = new Vector3((float)(-0.5), (float)(0.5), (float)(0.5)); //A
                vertices[1] = new Vector3((float)(0.5), (float)(0.5), (float)(0.5)); //B
                vertices[2] = new Vector3((float)(-0.5), (float)(-0.5), (float)(0.5)); //C
                vertices[3] = new Vector3((float)(0.5), (float)(-0.5), (float)(0.5)); //D
                break;
            case ("south"):
                vertices[0] = new Vector3((float)(0.5), (float)(0.5), (float)(-0.5)); //F
                vertices[1] = new Vector3((float)(-0.5), (float)(0.5), (float)(-0.5)); //E
                vertices[2] = new Vector3((float)(-0.5), (float)(-0.5), (float)(-0.5)); //G
                vertices[3] = new Vector3((float)(0.5), (float)(-0.5), (float)(-0.5)); //H
                break;
            case ("west"):
                vertices[0] = new Vector3((float)(0.5), (float)(0.5), (float)(0.5)); //B
                vertices[1] = new Vector3((float)(0.5), (float)(0.5), (float)(-0.5)); //F
                vertices[2] = new Vector3((float)(0.5), (float)(-0.5), (float)(0.5)); //D
                vertices[3] = new Vector3((float)(0.5), (float)(-0.5), (float)(-0.5)); //H
                break;
            case ("east"):
                vertices[0] = new Vector3((float)(-0.5), (float)(0.5), (float)(-0.5)); //E
                vertices[1] = new Vector3((float)(-0.5), (float)(0.5), (float)(0.5)); //A
                vertices[2] = new Vector3((float)(-0.5), (float)(-0.5), (float)(-0.5)); //G
                vertices[3] = new Vector3((float)(-0.5), (float)(-0.5), (float)(0.5)); //C
                break;
            case ("up"):
                vertices[0] = new Vector3((float)(-0.5), (float)(0.5), (float)(-0.5)); //E
                vertices[1] = new Vector3((float)(0.5), (float)(0.5), (float)(-0.5)); //F
                vertices[2] = new Vector3((float)(-0.5), (float)(0.5), (float)(0.5)); //A
                vertices[3] = new Vector3((float)(0.5), (float)(0.5), (float)(0.5)); //B
                break;
            case ("down"):
                vertices[0] = new Vector3((float)(-0.5), (float)(-0.5), (float)(-0.5)); //G
                vertices[1] = new Vector3((float)(0.5), (float)(-0.5), (float)(-0.5)); //H
                vertices[2] = new Vector3((float)(-0.5), (float)(-0.5), (float)(0.5)); //C
                vertices[3] = new Vector3((float)(0.5), (float)(-0.5), (float)(0.5)); //D
                break;
            default:
                break;
        }

    }

    void Start() {
        Face Face01 = new Face(BlockTexture, "north");
        Face Face02 = new Face(BlockTexture, "south");
        //Face Face03 = new Face(BlockTexture, "west");
        //Face Face04 = new Face(BlockTexture, "east");
        //Face Face05 = new Face(BlockTexture, "up");
        //Face Face06 = new Face(BlockTexture, "down");

    }
    
    void Update() {

    }

}