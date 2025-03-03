﻿using Application.Services.Abstract;
using Core.Constants;
using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using Data.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class GroupService : IGroupService
    {
        private readonly UnitOfWork _unitOfWork;
        public GroupService()
        {
            _unitOfWork = new UnitOfWork();

        }
        public void CreateGroup()
        {
        GroupName:
            Messages.InputMessage("Group name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Group name");
                goto GroupName;
            }
            Group group = new Group
            {
                Name = name,

            };
            _unitOfWork.Groups.Add(group);
            Messages.SuccessMessage("Group", "Added");
            _unitOfWork.Commit();
        }
        public void RemoveGroup()
        {

        IdInput:
            Messages.InputMessage("Id");
            string inputId = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(inputId, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("id");
                goto IdInput;
            }

            Group group = _unitOfWork.Groups.Get(id);
            if (group == null)
            {
                Messages.NotFoundMessage("Group");
                return;
            }

            _unitOfWork.Groups.Delete(group);
            Messages.SuccessMessage("Group", "Deleted");
            _unitOfWork.Commit();
        }
        public void UpdateGroup()
        {

        IdInput:
            Messages.InputMessage("id");
            string inputId = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(inputId, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("id");
                goto IdInput;
            }

            Group group = _unitOfWork.Groups.Get(id);
            if (group == null)
            {
                Messages.NotFoundMessage("Group");
                return;
            }

        GroupNameInput:
            Messages.InputMessage("Name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name");
                goto GroupNameInput;
            }

            group.Name = name;
            _unitOfWork.Groups.Update(group);
            Messages.SuccessMessage("Updated", "Group");
            _unitOfWork.Commit();
        }
        public void GetAllGroups()
        {
            foreach (var group in _unitOfWork.Groups.GetAll())
            {
                Console.WriteLine($"Name: {group.Name} ");
            }
            _unitOfWork.Commit();

        }
        public void GetGroupByName()
        {

        InputNameSection:
            Messages.InputMessage("Name");
            string inputName = Console.ReadLine();
            foreach (var group in _unitOfWork.Groups.GetAll())
            {
                if (group.Name == inputName)
                {

                    Console.WriteLine($"Name: {group.Name}");
                }
            }
            Messages.NotFoundMessage("Group");
            goto InputNameSection;




        }
        
        


    }
}
