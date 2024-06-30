using CoreWebApiV08.API.Models.Lesson;

namespace CoreWebApiV08.API.Repositories.Interface
{
    public interface ILesson
    {
        Task<List<CourseLession>>GetAllLessonAsync();

        Task<CourseLession> GetLessionBycourseIdAsync(int CourseId);
    }
}
