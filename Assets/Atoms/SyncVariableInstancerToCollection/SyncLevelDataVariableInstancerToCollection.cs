using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type LevelData to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync LevelData Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncLevelDataVariableInstancerToCollection : SyncVariableInstancerToCollection<LevelData, LevelDataVariable, LevelDataVariableInstancer> { }
}
