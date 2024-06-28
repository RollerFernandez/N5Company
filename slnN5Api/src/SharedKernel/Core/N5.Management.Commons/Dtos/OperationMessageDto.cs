using System;
using System.Collections.Generic;
namespace N5.Management.Commons.Dtos
{
    public class OperationMessageDto
    {
        public Guid Id { get; set; }
        public string OperationName { get; set; }

        public OperationMessageDto(string operationName)
        {
            Id = Guid.NewGuid();
            OperationName = operationName;
        }
    }
}
