namespace API.Helper
{
    public class Pagination<T> where T : class
    {

        public Pagination(int pageIndex,int pageSize,int count,IReadOnlyList<T> data)
        {
            _pageSize = pageSize;
            _pageIndex = pageIndex;
            _count = count;
            _data = data;
        }
        public int _pageIndex { get; set; }
        public int _pageSize { get; set; }
        public int _count { get; set; }
        public IReadOnlyList<T> _data { get; set; }

    }
}
