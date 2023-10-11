using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EVO.Core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetup;

    public void ChangeColorByType(ArtManager.ArtType artType)
    {
        var setup = colorSetup.Find(i => i.artType == artType);

        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_EmissionColor", setup.colors[i]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
