namespace Coach_s_Log.DTO.LessonDTO
{
    public record class LessonRequest(
        Guid CoachId,
        Guid GroupId,
        short Price,
        DateOnly Date,
        TimeOnly Time        
        );

}
