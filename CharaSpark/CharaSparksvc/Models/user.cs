//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CharaSparksvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.donations = new HashSet<donation>();
            this.wishes = new HashSet<wish>();
        }
    
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string former_name { get; set; }
        public string login_id { get; set; }
        public string e_mail { get; set; }
        public System.DateTime create_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public bool is_active { get; set; }
        public bool is_donor { get; set; }
    
        public virtual ICollection<donation> donations { get; set; }
        public virtual ICollection<wish> wishes { get; set; }
    }
}
