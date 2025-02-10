using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Absence
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AbsenceID { get; set; }
    public int EmployeeId { get; set; }
    public int AbsenceTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Notes { get; set; }
    public Employee Employee { get; set; }
}