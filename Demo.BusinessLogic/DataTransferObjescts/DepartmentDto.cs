﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObjescts
{
    public class DepartmentDto
    {
        public int DeptId {  get; set; }
        public string Name { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public DateOnly DateOfCreation {  get; set; }
    }
}
