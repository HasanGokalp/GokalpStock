namespace GokalpStock.Application.Concrete.Wrapper
{
    public class Result<T>
        where T : new()
    {
        public T Data { get; set; }
        public bool Succsess { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
