namespace Quan_ly_quan_an.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillInfoes = new HashSet<BillInfo>();
        }

        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CheckOut { get; set; }

        public int TableID { get; set; }

        public int Discount { get; set; }

        public int? TotalPrice { get; set; }

        public int Status { get; set; }

        public virtual TableFood TableFood { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillInfo> BillInfoes { get; set; }
    }
}
