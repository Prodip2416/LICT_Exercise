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

    public partial class ArticleFile
    {
        public int id { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string file { get; set; }
    
        public virtual article article { get; set; }
    }
}
