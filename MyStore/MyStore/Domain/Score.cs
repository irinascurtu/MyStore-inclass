using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Domain;

[PrimaryKey("Testid", "Studentid")]
[Index("Testid", "Score1", Name = "idx_nc_testid_score")]
public partial class Score
{
    [Key]
    [Column("testid")]
    [StringLength(10)]
    [Unicode(false)]
    public string Testid { get; set; } = null!;

    [Key]
    [Column("studentid")]
    [StringLength(10)]
    [Unicode(false)]
    public string Studentid { get; set; } = null!;

    [Column("score")]
    public byte Score1 { get; set; }

    [ForeignKey("Testid")]
    [InverseProperty("Scores")]
    public virtual Test Test { get; set; } = null!;
}
