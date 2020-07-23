using APINetCoreDemo.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace APINetCoreDemo.Services.Implementation
{
    public class GroupServiceImpl : IGroupService
    {
        private volatile int count;

        public Group Create(Group group)
        {
            return group;
        }

        public void Delete(long id)
        {
           
        }

        public List<Group> FindAll()
        {
            List<Group> groups = new List<Group>();
            for (int i = 0; i < 8; i++)
            {
                Group group = MockGroups(i);
                groups.Add(group);
            }
            return groups;
        }

        private Group MockGroups(int i)
        {
            return new Group
            {
                Id = IncrementAndGet(),
                DisplayName = "",
                EmailAddress = "",
                SamAccountName = "",
                ObjectSid = "",
                Domain = ""
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Group FindById(long id)
        {
            return new Group
            {
                Id = IncrementAndGet(),
                DisplayName = "",
                EmailAddress = "",
                SamAccountName = "",
                ObjectSid = "",
                Domain = ""
            };
        }

        public Group Update(Group group)
        {
            return group;
        }
    }
}
