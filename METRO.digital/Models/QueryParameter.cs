namespace METRO.digital.Models;

public class QueryParameter
{
    private int _pageNumber = 1;

    public int PageNumber
    {
        get { return _pageNumber; }
        set { _pageNumber = value; }
    }

    private const int _maxPageSize = 50;
    private int _pageSize = 2;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = value > _maxPageSize ? _maxPageSize : value; }
    }
}