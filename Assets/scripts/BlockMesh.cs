using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class BlockMesh : MonoBehaviour {
    
    public Material material;
    private void Start() {

        /*
        Vector3[] vertices = {
            new Vector3(0, 1, 0), //a : 0
            new Vector3(1, 1, 0), //b : 1
            new Vector3(0, 0, 0), //c : 2
            new Vector3(1, 0, 0), //d : 3
            new Vector3(1, 1, 1), //e : 4
            new Vector3(0, 1, 1), //f : 5
            new Vector3(1, 0, 1), //g : 6
            new Vector3(0, 0, 1), //h : 7

        };
        Vector3[] vertices = new Vector3[8];
        Vector3 position = new Vector3(0, 0, 0);
        setVerticesPosition(position, vertices);

        Vector2[] uv = {
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(0, 0),
            new Vector2(1, 0),
        };

        int[] triangles = {
            0, 1, 2, //A
            2, 1, 3, //B
            4, 5, 6, //C
            6, 5, 7, //D
            1, 4, 3, //E
            3, 4, 6, //F
            5, 0, 7, //G
            7, 0, 2, //H
            5, 4, 0, //I
            0, 4, 1, //J
            2, 3, 7, //K
            7, 3, 6, //L

        };



        Mesh mesh = new Mesh();
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();

        GameObject block = new GameObject("mesh", typeof(MeshFilter), typeof(MeshRenderer));
        block.transform.localScale = new Vector3(1, 1, 1);

        block.GetComponent<MeshFilter>().mesh = mesh;
        block.GetComponent<MeshRenderer>().material = material;
        block.AddComponent<MeshCollider>();*/


        BlockMesh test = new BlockMesh(new Vector3(1, 10, 1));
        Mesh BlockMesh = new Mesh();
        BlockMesh.Clear();
        BlockMesh.vertices = BlockMesh.vertices;
        BlockMesh.uv = BlockMesh.uv;
        BlockMesh.triangles = BlockMesh.triangles;


    }

    // Update is called once per frame
    void update() {

    }

    public BlockMesh(Vector3 position) {
        Vector3[] vertices = new Vector3[8];
        Vector2[] uv;

        setVerticesPosition(position, vertices);

        int[] triangles = {
            0, 1, 2, //A
            2, 1, 3, //B
            4, 5, 6, //C
            6, 5, 7, //D
            1, 4, 3, //E
            3, 4, 6, //F
            5, 0, 7, //G
            7, 0, 2, //H
            5, 4, 0, //I
            0, 4, 1, //J
            2, 3, 7, //K
            7, 3, 6, //L
        };

    }
    private void setVerticesPosition(Vector3 position, Vector3[] vertices) {

        vertices[0] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //A
        vertices[1] = new Vector3((float)(position.x + 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //B
        vertices[2] = new Vector3((float)(position.x - 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //C
        vertices[3] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //D

        vertices[4] = new Vector3((float)(position.x + 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //E
        vertices[5] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //F
        vertices[6] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //G
        vertices[7] = new Vector3((float)(position.x - 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //D


    }

    private void setFaces(Vector3 position, Vector3[] vertices, string facing) {
        if (facing == "north") {
            vertices[0] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //A
            vertices[1] = new Vector3((float)(position.x + 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //B
            vertices[2] = new Vector3((float)(position.x - 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //C
            vertices[3] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //D
        } else if (facing == "south") {
            vertices[4] = new Vector3((float)(position.x + 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //E
            vertices[5] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //F
            vertices[6] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //G
            vertices[7] = new Vector3((float)(position.x - 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //D
        } else if (facing == "west") {
            vertices[0] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //A
            vertices[1] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //B
            vertices[2] = new Vector3((float)(position.x - 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //C
            vertices[3] = new Vector3((float)(position.x - 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //D
        } else if (facing == "east") {
            vertices[4] = new Vector3((float)(position.x + 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //E
            vertices[5] = new Vector3((float)(position.x + 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //F
            vertices[6] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //G
            vertices[7] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //D
        } else if (facing == "upwards") {
            vertices[0] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //A
            vertices[1] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //B
            vertices[2] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z - 0.5)); //C
            vertices[3] = new Vector3((float)(position.x - 0.5), (float)(position.y + 0.5), (float)(position.z + 0.5)); //D
        } else if (facing == "downwards") {
            vertices[4] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //E
            vertices[5] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //F
            vertices[6] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z + 0.5)); //G
            vertices[7] = new Vector3((float)(position.x + 0.5), (float)(position.y - 0.5), (float)(position.z - 0.5)); //D

        }
    }
}
