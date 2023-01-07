using College.MinApi.Dtos;

namespace College.MinApi.Helpers
{

    public static class DefaultApiResponse
    {
        public static ApiResponseDto<string> SendDefaultApiEndpointOutput()
        {
            return CollegeApiResponse.GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint");
        }

        public static ApiResponseDto<string> SendDefaultApiEndpointV1Output()
        {
            return CollegeApiResponse.GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint V1");
        }

    }

}
