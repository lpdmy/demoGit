namespace TeachMate.Domain;
public class PageQueryDto
{
    public int Page { get; set; } = 1;
    public int Take { get; set; } = 10;
    public int Skip() => (Page - 1) * Take;
}
