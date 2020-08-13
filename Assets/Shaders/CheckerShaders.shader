Shader "PeryLoth/CheckerShaders"
{
    Properties
    {
        _Color ("COlor Principal", Color) = (1,.5,.5,1)
    }
    SubShader
    {
        Pass
        {
            Material
            {
                Diffuse[_Color]
            }
            Lighting On
        }
    }
}
