#if CiDy
using CiDy;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using WizardsCode.Character; // Remove if not using my character controller code

namespace WizardsCode.CiDYExtension
{
    [CustomEditor(typeof(CiDyPedestrians), true)]
    public class CiDyPedestriansEditor : SpawnerEditor // If not using my character controller code use CustomEditor rather than SpawnerEditor
    {
        private CiDyGraph graph;
        private CiDyPedestrians peds;

        protected override void OnEnable()
        {
            base.OnEnable();
            SerializedProperty serializedGraph = serializedObject.FindProperty("cidyGraph");

            graph = (CiDyGraph)serializedGraph.objectReferenceValue;
            peds = (CiDyPedestrians)target;
        }

        public bool IsNavMeshSetup
        {
            get
            {
                bool isValid = true;
                isValid &= NavMesh.GetAreaFromName(peds.roadAreaName) >= 0;
                isValid &= NavMesh.GetAreaFromName(peds.crossingAreaName) >= 0;
                isValid &= NavMesh.GetAreaFromName(peds.pavementAreaName) >= 0;

                return isValid;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            if (!IsNavMeshSetup)
            {
                EditorGUILayout.LabelField("Please add the three NavMesh Areas (" + peds.roadAreaName + ", " + peds.crossingAreaName + ", " + peds.pavementAreaName + ") as defined above.");
            }
            else
            {
                if (graph != null)
                {
                    if (GUILayout.Button("Configure CiDy"))
                    {
                        // NOTE this assumes that you have configured NavMesh Areas for Road, Pedestrian Crossing and Pavement
                        // Road should have a higher cost than Pedestrian crossing, with Pavement having the lowest
                        // If you don't know how to do this see https://youtu.be/nzzS40XHWA8

                        //TODO Setup necessary NavMeshAreas if not already present
                        //as can be seen here (CiDY calls it a Sidewalk, I call it a Pavement)

                        ConfigureRoads();
                        ConfigureIntersections();
                        ConfigurePavements();
                        UnityEditor.AI.NavMeshBuilder.BuildNavMeshAsync();
                    }
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void ConfigurePavements()
        {
            List<CiDyCell> cells = graph.cells;
            for (int i = 0; i < cells.Count; i++)
            {
                //TODO is there a more robust way of getting the sidewalks?
                Transform sidewalk = cells[i].transform.Find("SideWalk");
                if (sidewalk != null)
                {
                    SetNavMeshArea(sidewalk.gameObject, peds.pavementAreaName);
                }
            }
        }

        private void ConfigureIntersections()
        {
            List<CiDyEdge> edges = graph.graphEdges;
            for (int i = 0; i < edges.Count; i++)
            {
                SetNavMeshArea(edges[i].v1.intersection, peds.roadAreaName);
                SetNavMeshArea(edges[i].v2.intersection, peds.roadAreaName);
            }
        }

        private void ConfigureRoads()
        {
            List<GameObject> roads = graph.roads;
            for (int i = 0; i < roads.Count; i++)
            {
                SetNavMeshArea(roads[i], peds.roadAreaName);

                // Configure crossings
                List<Transform> decals = roads[i].GetComponent<CiDyRoad>().decals;
                for (int idx = 0; idx < decals.Count; idx++)
                {
                    SetNavMeshArea(decals[idx].gameObject, peds.crossingAreaName);
                }
            }
        }

        /// <summary>
        /// Set the navmesh area on all MeshRenderer children of an object.
        /// Also set isStatic to true.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="nameOfNavMeshArea"></param>
        private static void SetNavMeshArea(GameObject obj, string nameOfNavMeshArea)
        {
            MeshRenderer[] renderers = obj.GetComponentsInChildren<MeshRenderer>();
            for (int idx = 0; idx < renderers.Length; idx++)
            {
                GameObjectUtility.SetNavMeshArea(renderers[idx].gameObject, NavMesh.GetAreaFromName(nameOfNavMeshArea));
                renderers[idx].gameObject.isStatic = true;
            }
        }
    }
}
#endif