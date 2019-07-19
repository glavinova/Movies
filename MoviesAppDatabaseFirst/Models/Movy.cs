//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoviesAppDatabaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Movy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movy()
        {
            this.Projections = new HashSet<Projection>();
            this.Reviews = new HashSet<Review>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int Duration { get; set; }
        [Display ( Name = " Rating ")]
        public decimal totalRaiting { get; set; }
        public string imgUrl { get; set; }

        public Nullable<int> Director_Id { get; set; }
        public Nullable<int> genre_Id { get; set; }
    
        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projection> Projections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
