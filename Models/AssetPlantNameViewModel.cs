using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyAssetAppASP.Models;

public class AssetPlantNameViewModel
{
    public List<Asset>? Assets { get; set; }
    public SelectList? PlantNames { get; set; }
    public string? AssetPlantName { get; set; }
    public string? SearchString { get; set; }
}