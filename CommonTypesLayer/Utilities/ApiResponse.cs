using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonTypesLayer.Utilities
{
    public class ApiResponse<T>
    {   //JSON formatında dışarıya açtığımız durum sınıfını ifade ediyor.
        public T Data { get; set; }
        [JsonIgnore] //Bu property sadece bizim kullanmamız için proje içinde kullanacağımız propertydir. Bu sınıf json'a dönüştürülürken bu property dönüştürülmeyecektir.
        public int StatusCode { get; set; }
        public List<string> ErrorMessage { get; set; }
        public static ApiResponse<T> Success(int statusCode, T Data)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Data = Data };
        }
        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T> { StatusCode = statusCode };
        }
        public static ApiResponse<T> Fail(int statusCode, string errorMessage) 
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = new List<string> { errorMessage }
            };
        }
        public static ApiResponse<T> Fail(int statusCode, List<string> errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
        }
    }
}
