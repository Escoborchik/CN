namespace Coach_s_Log.DTO.LessonDTO
{
    public record class LessonResponse(
        short Price,
        TimeOnly Time,
        DateOnly Date,
        string GroupName
        );
}
