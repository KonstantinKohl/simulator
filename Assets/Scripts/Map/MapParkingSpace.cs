/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.Map
{
    public class MapParkingSpace : MapDataPoints
    {
        public override void Draw()
        {
            if (mapLocalPositions.Count < 2) return;

            AnnotationGizmos.DrawWaypoints(transform, mapLocalPositions, MapAnnotationTool.PROXIMITY * 0.5f, parkingSpaceColor);
            AnnotationGizmos.DrawLines(transform, mapLocalPositions, parkingSpaceColor);
            if (MapAnnotationTool.SHOW_HELP)
            {
#if UNITY_EDITOR
                UnityEditor.Handles.Label(transform.position, "    PARKINGSPACE");
#endif
            }
        }
    }
}