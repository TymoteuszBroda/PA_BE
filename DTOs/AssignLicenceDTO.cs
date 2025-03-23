using System;

namespace PermAdminAPI.DTOs;

public class AssignLicenceDTO
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int LicenceId { get; set; }
    public string EmployeeName { get; set; }
    public string LicenceName { get; set; }
}
