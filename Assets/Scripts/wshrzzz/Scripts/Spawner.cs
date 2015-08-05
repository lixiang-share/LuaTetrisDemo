using UnityEngine;
using System.Collections;

namespace Wshrzzz.UnityUtil
{
    public class Spawner : MonoBehaviour
    {

        private SpawnShape m_ShapeType = SpawnShape.None;
        private float m_CubeX;
        private float m_CubeY;
        private float m_CubeZ;
        private float m_SphereRadius;
        private Vector3 m_OriginPoint;

        /// <summary>
        /// Spawn in a cube space.
        /// </summary>
        /// <param name="spawnerPos">Spawn center point in local position.</param>
        /// <param name="spawnerRotation">Rotation of the cube space.</param>
        /// <param name="x">Cube x.</param>
        /// <param name="y">Cube y.</param>
        /// <param name="z">Cube z.</param>
        /// <param name="isOnShell">Spawn in whole cube space or only on cube shell.</param>
        public void SetupSpawner(Vector3 spawnerPos, Quaternion spawnerRotation, float x, float y, float z, bool isOnShell = false)
        {
            transform.localPosition = spawnerPos;
            transform.rotation = spawnerRotation;
            m_ShapeType = isOnShell ? SpawnShape.CubeShell : SpawnShape.Cube;
            m_CubeX = Mathf.Clamp(x, 0f, Mathf.Infinity);
            m_CubeY = Mathf.Clamp(y, 0f, Mathf.Infinity);
            m_CubeZ = Mathf.Clamp(z, 0f, Mathf.Infinity);
            m_OriginPoint = transform.position - transform.right * m_CubeX * 0.5f - transform.up * m_CubeY * 0.5f - transform.forward * m_CubeZ * 0.5f;
        }

        /// <summary>
        /// Spawn in a sphere space.
        /// </summary>
        /// <param name="spawnerPos">Spawn center point in local position.</param>
        /// <param name="radius">Sphere radius.</param>
        /// <param name="isOnShell">Spawn in whole sphere space or only on sphere shell.</param>
        public void SetupSpawner(Vector3 spawnerPos, float radius, bool isOnShell = false)
        {
            transform.localPosition = spawnerPos;
            m_ShapeType = isOnShell ? SpawnShape.SphereShell : SpawnShape.Sphere;
            m_SphereRadius = Mathf.Clamp(radius, 0f, Mathf.Infinity);
            m_OriginPoint = spawnerPos;
        }

        /// <summary>
        /// Spawn a object.
        /// </summary>
        /// <param name="objectForSpawn">Object which will instantiate.</param>
        /// <param name="objectRotation">Object's rotation when instantiate.</param>
        public void Spawn(Transform objectForSpawn, Quaternion objectRotation)
        {
            Vector3 spawnPoint = m_OriginPoint;
            switch (m_ShapeType)
            {
                case SpawnShape.None:
                    Debug.LogWarning("Spawner isn't inited.");
                    break;
                case SpawnShape.Cube:
                    spawnPoint += Random.Range(0f, 1f) * m_CubeZ * transform.forward;
                    spawnPoint += Random.Range(0f, 1f) * m_CubeY * transform.up;
                    spawnPoint += Random.Range(0f, 1f) * m_CubeX * transform.right;
                    Instantiate(objectForSpawn, spawnPoint, objectRotation);
                    break;
                case SpawnShape.CubeShell:
                    Vector3 xV3 = Random.Range(0f, 1f) * m_CubeX * transform.right;
                    Vector3 yV3 = Random.Range(0f, 1f) * m_CubeY * transform.up;
                    Vector3 zV3 = Random.Range(0f, 1f) * m_CubeZ * transform.forward;

                    float temp = Random.Range(0f, 6f);
                    if (temp <= 1f)
                    {
                        xV3 = Vector3.zero;
                    }
                    else if (temp <= 2f)
                    {
                        xV3 = m_CubeX * transform.right;
                    }
                    else if (temp <= 3f)
                    {
                        yV3 = Vector3.zero;
                    }
                    else if (temp <= 4f)
                    {
                        yV3 = m_CubeY * transform.up;
                    }
                    else if (temp <= 5f)
                    {
                        zV3 = Vector3.zero;
                    }
                    else if (temp <= 6f)
                    {
                        zV3 = m_CubeZ * transform.forward;
                    }

                    spawnPoint = m_OriginPoint + xV3 + yV3 + zV3;
                    Instantiate(objectForSpawn, spawnPoint, objectRotation);
                    break;
                case SpawnShape.Sphere:
                    spawnPoint += (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized * m_SphereRadius * Random.Range(0f, 1f);
                    Instantiate(objectForSpawn, spawnPoint, objectRotation);
                    break;
                case SpawnShape.SphereShell:
                    spawnPoint += (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))).normalized * m_SphereRadius;
                    Instantiate(objectForSpawn, spawnPoint, objectRotation);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Init spawner by a static method.
        /// </summary>
        /// <param name="parentGO">Spawner's parent, default is null.</param>
        /// <param name="spawnerName">Spawner's name, default is "".</param>
        /// <returns></returns>
        public static Spawner InitSpawner(GameObject parentGO = null, string spawnerName = "")
        {
            GameObject go = new GameObject();
            go.name = spawnerName == "" ? "Spawner" : spawnerName + " Spawner";
            go.AddComponent<Spawner>();
            if (parentGO != null)
            {
                go.transform.parent = parentGO.transform;
            }
            return go.GetComponent<Spawner>();
        }

        public void DeinitSpawner()
        {
            Destroy(gameObject);
        }

        public enum SpawnShape
        {
            None,
            Cube,
            CubeShell,
            Sphere,
            SphereShell
        }
    }
}

