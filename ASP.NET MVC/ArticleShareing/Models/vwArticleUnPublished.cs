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
    
    public partial class vwArticleUnPublished
    {
        public int id { get; set; }
        public string title { get; set; }
        public string Tags { get; set; }
        public int categoryId { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public System.DateTime dateTime { get; set; }
        public string IP { get; set; }
        public int SubscriptionTypeId { get; set; }
    }
}