namespace App.DTOs;
public class PagedParams
{
    private const int _maxItemsPerPage = 50;
    private int itemsPerPage;
    public int Page { get; set; }
    public int ItemsPerPage
    {
        get => itemsPerPage;
        set => itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
    }
}