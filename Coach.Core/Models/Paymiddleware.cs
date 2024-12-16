namespace Coach.Core.Models
{
    public record class Paymiddleware
        (
        string FullName,
        List<AttendanceMiddleware> Attendance,
        int Sum,
        int Paid

        );

    public record class AttendanceMiddleware(
        DateOnly Date,
        bool IsPresent);
    
}
