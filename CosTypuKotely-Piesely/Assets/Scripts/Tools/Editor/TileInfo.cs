using System.Collections.Generic;

public class TileInfo
{
    BaseInfo baseInfoCache;
    List<Field> fields = new List<Field>();

    public BaseInfo BaseInfoCache { get => baseInfoCache; set => baseInfoCache = value; }
    public List<Field> Fields { get => fields; set => fields = value; }

    public TileInfo(BaseInfo i)
    {
        BaseInfoCache = i;
    }

    public void Add(Field f)
    {
        Fields.Add(f);
    }
}
