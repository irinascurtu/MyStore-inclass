using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Domain;

public partial class Test
{
    [Key]
    [Column("testid")]
    [StringLength(10)]
    [Unicode(false)]
    public string Testid { get; set; } = null!;

    [InverseProperty("Test")]
    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
