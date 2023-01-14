using College.Data.Dtos;

namespace College.MinApi.Helpers
{

    public static class CollegeApiResponse
    {

        public static ApiResponseDto<T> GenerateCollegeApiResponse<T>(T? data = default,
            string message = "Success", bool success = true)
        {
            return new ApiResponseDto<T>
            {
                Success = success,
                Message = message,
                Data = data
            };
        }

    }

}
