//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDJArticle15.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ArticleComment
    {
        public int Id { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string Comments { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public int UserId { get; set; }
        public string IP { get; set; }
    
        public virtual article article { get; set; }
        public virtual User User { get; set; }
    }
}