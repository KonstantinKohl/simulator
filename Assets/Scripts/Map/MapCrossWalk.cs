/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simulator.Map;

namespace Simulator.Map
{
    public class MapCrossWalk : MapDataPoints
    {
        public override void Draw()
        {
            if (mapLocalPositions.Count < 3) return;

            AnnotationGizmos.DrawWaypoints(transform, mapLocalPositions, MapAnnotationTool.PROXIMITY * 0.5f, crossWalkColor);
            AnnotationGizmos.DrawLines(transform, mapLocalPositions, crossWalkColor);
            if (MapAnnotationTool.SHOW_HELP)
            {
#if UNITY_EDITOR
                UnityEditor.Handles.Label(transform.position, "    CROSSWALK");
#endif
            }
        }
    }
}