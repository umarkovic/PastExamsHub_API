using GBI.EnterpriseServices.Storage.StorageApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBI.EnterpriseServices.Storage.Application.UnitTests.Stub
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Role { get; set; }

        public string UserUid { get; set; }

        public string AccountUid { get; set; }

        public bool IsInRole(string role)
        {
            return this.Role == role;
        }
    }
}
