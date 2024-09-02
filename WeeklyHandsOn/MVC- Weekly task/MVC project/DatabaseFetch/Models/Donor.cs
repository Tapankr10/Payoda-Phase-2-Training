using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Donor
{
    public int DonorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string BloodType { get; set; } = null!;

    public string? ContactNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? LastDonationDate { get; set; }

    public virtual ICollection<BloodUnit> BloodUnits { get; set; } = new List<BloodUnit>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
