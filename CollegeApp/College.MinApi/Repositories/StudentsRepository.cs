using College.MinApi.Dtos;
using College.MinApi.Helpers;

namespace College.MinApi.Repositories
{

    public static class StudentsRepository
    {

        public static ApiResponseDto<IEnumerable<StudentDto>> GetAllStudents()
        {
            IList<StudentDto> students = StudentDto.GetDummyStudents();

            return CollegeApiResponse.GenerateCollegeApiResponse<IEnumerable<StudentDto>>(students);
        }

    }

}
