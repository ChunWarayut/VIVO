﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VIVO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class UserAccout
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccout()
        {
            this.ProductOrders = new HashSet<ProductOrder>();
        }

        [DisplayName("รหัสสมาชิก")]
        public string User_Id_ { get; set; }
        [DisplayName("ชื่อ")]
        public string User_Name { get; set; }
        [DisplayName("นามสกุล")]
        public string User_Lastname { get; set; }
        [DisplayName("เพศ")]
        public string User_Sex { get; set; }
        [DisplayName("เบอร์โทรศัพท์")]
        public string User_Tel { get; set; }
        [DisplayName("Email")]
        public string User_Email { get; set; }
        [DisplayName("ที่อยู่")]
        public string User_Address { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
