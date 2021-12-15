using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;
    Editor terrainShapeEditor;
    Editor colourEditor;

    public override void OnInspectorGUI()
    {
        using(var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();

            if(check.changed)
            {
                planet.GeneratePlanet();
            }
        }

        DrawSettingsEditor(planet.terrainShapeSettings, planet.OnTerrainShapeSettingsUpdate, ref planet.terrainShapeSettingsFoldout, ref terrainShapeEditor);
        DrawSettingsEditor(planet.colourSettings, planet.OnColourSettingsUpdate, ref planet.colourSettingsFoldout, ref colourEditor);    
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdate, ref bool foldout, ref Editor editor)
    {
        if(settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);

            using(var check = new EditorGUI.ChangeCheckScope())
            {
                if(foldout)
                {
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();

                    if(check.changed)
                    {
                        if(onSettingsUpdate != null)
                        {
                            onSettingsUpdate();
                        }
                    }
                }
                
            }
        }
    }

    private void OnEnable()
    {
        planet = (Planet) target;
    }
}
