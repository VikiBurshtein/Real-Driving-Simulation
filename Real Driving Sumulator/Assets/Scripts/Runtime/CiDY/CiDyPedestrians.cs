#if CiDy
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WizardsCode.Utility; // Remove if not using my character controller code
using WizardsCode.Character;  // Remove if not using my character controller code
using CiDy;

namespace WizardsCode.CiDYExtension
{
    /// <summary>
    /// Extends the Wizards Code Spawner with features to automatically configure the NavMesh Areas in a
    /// CiDy generated city.
    /// </summary>
    public class CiDyPedestrians : Spawner // If not using my character controller code use MonoBehaviour rather than Spawner
    {
        [SerializeField, Tooltip("The CiDy graph object that manages the generation of the city.")]
        CiDyGraph cidyGraph;
        [SerializeField, Tooltip("The name of the navmesh area to use for roads and junctions.")]
        public string roadAreaName = "Road";
        [SerializeField, Tooltip("The name of the navmesh area to use for road crossings.")]
        public string crossingAreaName = "Crossing";
        [SerializeField, Tooltip("The name of the navmesh area to use for pavement/sidewalk.")]
        public string pavementAreaName = "Pavement";
    }
}
#endif