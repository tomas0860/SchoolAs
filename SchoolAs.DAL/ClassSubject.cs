//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolAs.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassSubject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassSubject()
        {
            this.SubjectAssignment = new HashSet<SubjectAssignment>();
        }
    
        public long ClassSubjectId { get; set; }
        public string Name { get; set; }
        public long FK_ClassId { get; set; }
    
        public virtual Class Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectAssignment> SubjectAssignment { get; set; }
    }
}
