using College.MinApi.Dtos;

namespace College.MinApi.Helpers
{

    public static class CollegeApiResponseHelper
    {

        public static CollegeApiResponseDto<T> GenerateCollegeApiResponse<T>(T? data = default,
            string message = "Success", bool success = true)
        {
            return new CollegeApiResponseDto<T>
            {
                Success = success,
                Message = message,
                Data = data
            };
        }

    }

}
