using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Block;
using static Face;

public class Terrain : MonoBehaviour {

    public Material BlockMaterial;
    public GameObject Player;
    public GameObject BlockContainer;
    float freq;
    float active;
    float seed;

    
    void Start() {
        generate_terrain();

    }

    void update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Player.transform.position = new Vector3(Player.transform.position.x, 100, Player.transform.position.z);
            generate_terrain();
        }
    }


    void generate_terrain() {
        freq = Random.Range(10, 30);
        active = Random.Range(10, 30);
        seed = Random.Range(10, 1000);
        for (int x = 0; x < 100; x++) {
            for (int z = 0; z < 100; z++) {
                float y = Mathf.PerlinNoise(x / freq, z / freq) * active;
                y = Mathf.RoundToInt(y);
                
                Vector3 position = new Vector3(x, y, z);
                Block block = new Block();
                GameObject block_obj = new GameObject("mesh", typeof(MeshFilter), typeof(MeshRenderer));
                block_obj.transform.localScale = new Vector3(1, 1, 1);
                block_obj.GetComponent<MeshFilter>().mesh = block.getMesh();
                block_obj.AddComponent<MeshCollider>();
                block_obj.transform.position = position;
                block_obj.GetComponent<MeshRenderer>().material = BlockMaterial;
                block_obj.transform.parent = BlockContainer.transform;

            }
        }
    }

    /// <summary>
    /// genetare_around() is meant to generate blocks around the Player object
    /// take the position from Player to do so
    /// 
    /// bugs:
    /// ~it is meant for update function, this means it would creat blocks constatly
    /// ~
    /// 
    /// </summary>
    void generate_around() {

        for (int x = Mathf.RoundToInt(Player.transform.position.x); x < 50; x++) {
            for (int z = Mathf.RoundToInt(Player.transform.position.z); z < 50; z++) {
                float y = Mathf.PerlinNoise(x / freq, z / freq) / Random.Range(32, 64) / seed * active;

                Vector3 position = new Vector3(x, Mathf.RoundToInt(y), z);
                Block block = new Block();
                GameObject block_obj = new GameObject("mesh", typeof(MeshFilter), typeof(MeshRenderer));
                block_obj.transform.localScale = new Vector3(1, 1, 1);
                block_obj.GetComponent<MeshFilter>().mesh = block.getMesh();
                block_obj.AddComponent<MeshCollider>();
                block_obj.transform.position = position;
                block_obj.GetComponent<MeshRenderer>().material = BlockMaterial;
                block_obj.transform.parent = BlockContainer.transform;

            }
        }
    }
    /*
    void render_rules() {
        foreach (GameObject block in transform) {
            if ((Player.transform.position.x) - (block.transform.position.x) >50) {
                GameObject.Destroy(block);
            }
        }
    }
    */
}
