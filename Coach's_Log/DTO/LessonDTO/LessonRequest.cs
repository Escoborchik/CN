namespace Coach_s_Log.DTO.LessonDTO
{
    public record class LessonRequest(
        DateTime DateTime,
        Guid Coach,
        Guid Group);

}
