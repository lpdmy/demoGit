namespace TeachMate.Domain;
public class PageDto<T>
{
    public IEnumerable<T> Data { get; init; }
    public PageMetaDto Meta { get; init; }
    public PageDto(IEnumerable<T> data, PageMetaDto meta)
    {
        Data = data;
        Meta = meta;
    }
}
