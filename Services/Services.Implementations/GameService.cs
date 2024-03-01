using Services.Abstractions;

namespace Services.Implementations
{
    /// <summary>
    /// Cервис работы с играми
    /// </summary>
    public class GameService : IGameService
    {

        public GameService()
        {
        }

        ///// <summary>
        ///// Получить
        ///// </summary>
        ///// <param name="id">идентификатор</param>
        ///// <returns>ДТО курса</returns>
        //public async Task<CourseDto> GetById(int id)
        //{
        //    var course = await _courseRepository.GetAsync(id);
        //    return _mapper.Map<CourseDto>(course);
        //}
    }
}