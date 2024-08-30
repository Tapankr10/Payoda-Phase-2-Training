using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int UnitId { get; set; }

    public int? DonorId { get; set; }

    public int? RecipientId { get; set; }

    public string TransactionType { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    public virtual Donor? Donor { get; set; }

    public virtual Recipient? Recipient { get; set; }

    public virtual BloodUnit Unit { get; set; } = null!;
}
