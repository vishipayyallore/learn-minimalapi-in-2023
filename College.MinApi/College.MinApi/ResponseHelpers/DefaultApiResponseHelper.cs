using College.MinApi.Dtos;

namespace College.MinApi.Helpers
{
    
    public static class DefaultApiResponseHelper
    {
        public static CollegeApiResponseDto<string> SendDefaultApiEndpointOutput()
        {
            return CollegeApiResponseHelper.GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint");
        }

        public static CollegeApiResponseDto<string> SendDefaultApiEndpointV1Output()
        {
            return CollegeApiResponseHelper.GenerateCollegeApiResponse<string>("Welcome to Minimal API Endpoint V1");
        }

    }

}
