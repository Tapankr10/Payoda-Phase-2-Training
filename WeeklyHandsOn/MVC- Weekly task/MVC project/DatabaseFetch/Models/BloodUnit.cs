using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class BloodUnit
{
    public int UnitId { get; set; }

    public string BloodType { get; set; } = null!;

    public DateOnly CollectionDate { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public int? DonorId { get; set; }

    public string? Status { get; set; }

    public virtual Donor? Donor { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
