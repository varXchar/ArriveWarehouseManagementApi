using Newtonsoft.Json.Linq;

namespace ArriveWarehouseManagementApi.Models
{
    public class Result
    {
        private bool Success { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public Result() { }
        public Result(bool success) => Success = success;
        public virtual bool IsSuccessful => Success;
    }

    public class Result<T> : Result where T : class
    {
        public T Value { get; set; }
        public override bool IsSuccessful => Value != null;
    }
}
