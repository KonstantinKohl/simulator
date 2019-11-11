/**
 * Copyright (c) 2019 Daimler Autonomous Services
 */

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/RenderPipeline/ShaderPass/VertMesh.hlsl"

PackedVaryingsType Vert(AttributesMesh inputMesh)
{
    VaryingsType varyingsType;
    varyingsType.vmesh = VertMesh(inputMesh);
    return PackVaryingsType(varyingsType);
}

void Frag(PackedVaryingsToPS packedInput,
        out float4 outColor : SV_Target
        #ifdef _DEPTHOFFSET_ON
            , out float outputDepth : SV_Depth
        #endif
          )
{
#if defined(_SURFACE_TYPE_TRANSPARENT) || defined(_DEPTHOFFSET_ON)
    FragInputs input = UnpackVaryingsMeshToFragInputs(packedInput.vmesh);
    PositionInputs posInput = GetPositionInput(input.positionSS.xy, _ScreenSize.zw, input.positionSS.z, input.positionSS.w, input.positionRWS.xyz);
#endif

#if defined(_SURFACE_TYPE_TRANSPARENT)
    float3 V = float3(1.0, 1.0, 1.0);

    SurfaceData surfaceData;
    BuiltinData builtinData;
    GetSurfaceAndBuiltinData(input, V, posInput, surfaceData, builtinData);

    clip(builtinData.opacity - 0.5);
#endif

    outColor = _InstanceColor;

#ifdef _DEPTHOFFSET_ON
    outputDepth = posInput.deviceDepth;
#endif
}