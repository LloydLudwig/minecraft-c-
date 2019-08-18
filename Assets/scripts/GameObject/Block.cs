using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Block {
    Mesh block;

    public Block() {
        //Vector3[] vertices = new Vector3[8];
        //setVerticesPosition(position, vertices);

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

        this.block = block;
        block = new Mesh();
        block.Clear();
        block.vertices = vertices;
        block.uv = uv;
        block.triangles = triangles;

        /*
        GameObject block_obj = new GameObject("mesh", typeof(MeshFilter), typeof(MeshRenderer));
        block_obj.transform.localScale = new Vector3(1, 1, 1);

        block_obj.GetComponent<MeshFilter>().mesh = block;
        block_obj.AddComponent<MeshCollider>();
        */

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

    public Mesh getMesh() {
        return this.block;
    }

    public void make_GameObject(Texture block_texture, Material block_material) {
        block_texture.texelSize.Scale(new Vector2(32, 32));
        Mesh mesh_block = this.block;
        GameObject game_object;
        game_object = new GameObject("mesh", typeof(MeshFilter), typeof(MeshRenderer));
        game_object.transform.localScale = new Vector3(1, 1, 1);

        game_object.GetComponent<MeshFilter>().mesh = mesh_block;
        game_object.AddComponent<MeshCollider>();
        //game_object.AddComponent<Material>();
        game_object.GetComponent<MeshRenderer>().material = block_material;
        //game_object.GetComponent<Material>().mainTexture = block_texture;
        game_object.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(game_object.transform.lossyScale.x * 0.5f, game_object.transform.lossyScale.x * 0.5f);
    }


}

