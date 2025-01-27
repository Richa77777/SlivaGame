[System.Serializable]
public sealed class SaveLoadScriptZSerializer : ZSerializer.Internal.ZSerializer
{
    public SaveLoadScript PlayerSaveLoadScript;
    public System.Collections.Generic.List<InventorySpace.InventorySlot> _itemsList;
    public System.Collections.Generic.List<TasksSpace.TaskSlot> _tasksList;
    public System.Int32 groupID;
    public System.Boolean autoSync;

    public SaveLoadScriptZSerializer(string ZUID, string GOZUID) : base(ZUID, GOZUID)
    {       var instance = ZSerializer.ZSerialize.idMap[ZSerializer.ZSerialize.CurrentGroupID][ZUID];
         PlayerSaveLoadScript = (SaveLoadScript)typeof(SaveLoadScript).GetField("PlayerSaveLoadScript").GetValue(instance);
         _itemsList = (System.Collections.Generic.List<InventorySpace.InventorySlot>)typeof(SaveLoadScript).GetField("_itemsList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         _tasksList = (System.Collections.Generic.List<TasksSpace.TaskSlot>)typeof(SaveLoadScript).GetField("_tasksList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         groupID = (System.Int32)typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
         autoSync = (System.Boolean)typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(instance);
    }

    public override void RestoreValues(UnityEngine.Component component)
    {
         typeof(SaveLoadScript).GetField("PlayerSaveLoadScript").SetValue(component, PlayerSaveLoadScript);
         typeof(SaveLoadScript).GetField("_itemsList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, _itemsList);
         typeof(SaveLoadScript).GetField("_tasksList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, _tasksList);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("groupID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, groupID);
         typeof(ZSerializer.PersistentMonoBehaviour).GetField("autoSync", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(component, autoSync);
    }
}