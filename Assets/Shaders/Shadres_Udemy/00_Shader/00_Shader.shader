//Nombre
Shader "Personalizado/00_Shader"
{
    //propiedades que se ven en inspector del material
    Properties
    {
        _Color("Tint", Color) = (1,1,1,1)
    }

    //Subshaders
    SubShader
    {
        //Pass del shader
        Pass
        {
            //Todo el codigo va a qui
            CGPROGRAM
                //Codigo Aqui
                //propiedades para que compile
                //pragmas
                #pragma vertex vertexShader
                #pragma fragment fragmentShader

                //Union de propiedades y el sahder
                uniform fixed4 _Color;
                //Vertez input
                struct vertexIput
                {
                    fixed4 vertex : POSITION;
                };
                //vertes output
                struct vertexOutput
                {
                    fixed4 position : SV_POSITION;
                    fixed4 color : COLOR;
                };
                //vertes shader
                vertexOutput vertexShader(vertexIput i)
                {
                    vertexOutput o;
                    o.position = UnityObjectToClipPos(i.vertex);
                    o.color = _Color;
                    return o;
                }
                //fragment shader
                fixed4 fragmentShader(vertexOutput o) : SV_TARGET
                {
                    return o.color;
                }
                /*struct pixelOutput
                {
                    fixed4 pixel : SV_TARGET;
                };

                pixelOutput fragmentShader(vertexOutput o)
                {
                    pixelOutput p;
                    p.pixel = o.color;
                    return p;
                }*/

            ENDCG
        }
    }
    Fallback "Default"
}