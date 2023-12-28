using Photon.Pun;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject[] player;
    [SerializeField] Transform spawnPos;
    public float minXOffset, minZOffset, maxXOffset, maxZOffset;
    void Start()
    {
        Vector3 randomSpawnPos = new Vector3(
            Random.Range(
            spawnPos.position.x + minXOffset, spawnPos.position.x + maxXOffset), 
            spawnPos.position.y, 
            Random.Range(
                spawnPos.position.z + minZOffset, spawnPos.position.z + maxZOffset));
        PhotonNetwork.Instantiate(player[Random.Range(0, 1)].name, randomSpawnPos, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
