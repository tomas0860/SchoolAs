using System.Collections.Generic;

namespace SchoolAs.DAL.DTO
{
    public class StudentClassDto
    {
        public string FullName { get; set; }
        public string SchoolName { get; set; }
        public string Class { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }

    public class SubjectDto
    {
        public string Name { get; set; }
        public List<AssignmentDto> Assignments { get; set; }
    }

    public class AssignmentDto
    {
        public long AssignmentId { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
    }
}
