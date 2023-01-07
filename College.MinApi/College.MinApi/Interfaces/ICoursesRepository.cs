namespace College.MinApi.Interfaces
{

    public interface ICoursesRepository
    {
        Task<IResult> GetAllCourses();
    }

}
