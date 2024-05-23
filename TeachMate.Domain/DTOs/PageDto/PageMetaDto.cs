namespace TeachMate.Domain;
public class PageMetaDto
{
    public int Page { get; init; }
    public int Take { get; init; }
    public int PageCount => (ItemCount + Take - 1) / Take;
    public int ItemCount { get; init; }
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < PageCount;
    public PageMetaDto(PageQueryDto pageQueryDto, int itemCount)
    {
        Page = pageQueryDto.Page;
        Take = pageQueryDto.Take;
        ItemCount = itemCount;
    }
}
