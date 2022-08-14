using System.Collections.Generic;

public interface IEditorWindowData
{
    List<BaseInfo> Objects { get; set; }
#if UNITY_EDITOR
    public void AddBaseInstance(BaseInfo x);
    public void UpdateBaseInstance(BaseInfo x);
    public void RemoveBaseInstance(BaseInfo x);
#endif
}
