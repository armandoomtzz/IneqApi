using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqApi.Models
{
    public class MigrationHistory
    {
        public string MigrationId { get; set; }
        public string ContextKey { get; set; }
        public int Model { get; set; }
        public string ProductVersion { get; set; }

    }
}