using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[CustomEditor(typeof(IAEnemy))]
public class EnemyEditor : Editor
{
    private void OnSceneGUI()
    {
        IAEnemy _enem = (IAEnemy)target;

        Color c = Color.green;
        if (_enem.alertStage == AlertStage.Intrigued)
        {
            c = Color.Lerp(Color.green, Color.red, _enem.alertLevel / 100f);
        }
        else if (_enem.alertStage == AlertStage.Alerted)
        {
            c = Color.red;
        }

        Handles.color = new Color(c.r, c.g, c.b, 0.3f);
        Handles.DrawSolidArc(_enem.transform.position, _enem.transform.up, Quaternion.AngleAxis(-_enem.fovAngle / 2f, _enem.transform.up) * _enem.transform.forward, _enem.fovAngle, _enem.fov);
        Handles.color = c;
        _enem.fov = Handles.ScaleValueHandle(_enem.fov, _enem.transform.position + _enem.transform.forward * _enem.fov, _enem.transform.rotation, 3, Handles.SphereHandleCap, 1);
    }
}
