using College.Data.Dtos;

namespace College.MinApi.Helpers
{

    public static class DefaultApiResponse
    {
        public static ApiResponseDto<string> SendDefaultApiEndpointOutput()
        {
            return ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint");
        }

        public static ApiResponseDto<string> SendDefaultApiEndpointV1Output()
        {
            return ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint V1");
        }

    }

}
