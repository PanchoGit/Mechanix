using Mechanix.Common;
using System.Collections.Generic;

namespace Mechanix.Web.Models
{
    public class ResponseModel
    {
        public string Status { get; set; }

        public object Data { get; set; }

        public IEnumerable<ResultError> Errors { get; set; }
    }
}