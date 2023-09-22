using BusinessObject.Service.IService;
using DataAccess.IRepositories;
using DataAccess.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Service
{
	public class MemberService : IMemberService
	{
		IUnitRepository _unit;

		public MemberService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public void AddMember(Member member)
		{
            _unit.MemberRepository.Add(member);
            _unit.MemberRepository.Save();
        }

        public Member CheckLogin(string email, string password)
        {
			var members = GetMembers();
			if(members.Any())
			{
				var login = members.Where(x=> x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
				if(login != null)
				{
					return login;
				}
			 throw new NotFoundException("UserEntity not found");
            }
            throw new NotFoundException("UserEntity not found");
        }

        public void DeleteMember(Member member)
		{
            _unit.MemberRepository.Delete(member);
            _unit.MemberRepository.Save();
        }

		public Member GetMemberById(int id)
		{
            return _unit.MemberRepository.GetById(id);
        }

		public IEnumerable<Member> GetMembers()
		{
			return _unit.MemberRepository.GetAll();
		}

        public IEnumerable<Member> SearchMember(string searchs)
        {
            var members = GetMembers();
            searchs= searchs.ToLower();
            var membersSearch = members.Where(x => new[]
            {
                x.Email.ToLower(),
                x.Country.ToLower(),
                x.CompanyName.ToLower(),
                x.City.ToLower()
            }.Any(x=> x.Contains(searchs)));
            return membersSearch;
        }

        public bool UpdateMember(Member member)
		{
            var memberUpdate = GetMemberById(member.MemberId);
            if (memberUpdate != null)
            {
                memberUpdate.CompanyName = member.CompanyName;
                memberUpdate.Email = member.Email;
                memberUpdate.City = member.City;
                memberUpdate.Country = member.Country;
                memberUpdate.Password = member.Password;
                _unit.MemberRepository.Update(memberUpdate);
                _unit.MemberRepository.Save();
                return true;
            }
            return false;
        }
	}
}
