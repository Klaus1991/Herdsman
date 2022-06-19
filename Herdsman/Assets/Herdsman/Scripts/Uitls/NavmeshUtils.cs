using UnityEngine;
using UnityEngine.AI;

namespace Herdsman.Utils
{
    public static class NavmeshUtils
    {
        public static readonly int FieldArea = NavMesh.GetAreaFromName("Filed");
        public static readonly int YardArea = NavMesh.GetAreaFromName("Yard");

        public static Vector3 RandomNavmeshLocation(Vector3 position, float radius, int area)
        {
            var queryFilter = new NavMeshQueryFilter();
            queryFilter.areaMask = 1 << area;
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, queryFilter))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }
    }
}
