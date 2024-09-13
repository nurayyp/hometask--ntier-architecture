using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstract
{
    public interface IGroupService
    {
        public void CreateGroup() { }
        public void RemoveGroup() { }
        public void UpdateGroup() { }
        public void GetAllGroups() { }
        public void GetGroupById() { }
    }
}
