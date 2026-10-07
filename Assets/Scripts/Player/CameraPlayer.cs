using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Camera cameraPlayer;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask layerToHide;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private Vector3 boxHalfExtents = new Vector3(15f, 15f, 15f);
    private HashSet<MeshRenderer> meshHidden=new();
    

    private void Update()
    {
        meshUnhide();
        meshHide();

    }
    private void meshHide()
    {
        Vector3 origin= cameraPlayer.transform.position;
        Vector3 direction = player.transform.position - origin;
        float distance = direction.magnitude;

        RaycastHit[] hits = Physics.BoxCastAll(
        origin,
        boxHalfExtents,
        direction.normalized,
        Quaternion.identity,
        distance,
        layerToHide);

        foreach (RaycastHit hit in hits)
        {
            MeshRenderer[] meshes= hit.collider.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in meshes)
            {
                mesh.enabled=false;
                meshHidden.Add(mesh);
            }
        }
    }
    private void meshUnhide()
    {
        foreach (MeshRenderer mesh in meshHidden)
        {
            if (mesh != null)
            {
                mesh.enabled = true;
            }
        }

        meshHidden.Clear();
    }
    private void OnDrawGizmos()
    {
        if (player == null || cameraPlayer == null)
            return;

        Vector3 origin = cameraPlayer.transform.position;

        Vector3 direction = player.transform.position - origin;

        float distance = direction.magnitude;

        // Ray
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(
            origin,
            cameraPlayer.transform.position
        );

        Gizmos.color = Color.yellow;

        Gizmos.matrix=Matrix4x4.TRS(
            origin,Quaternion.identity,boxHalfExtents*2f
        );

        Gizmos.DrawWireCube( Vector3.zero, Vector3.one );



    }
}
